using MediatR;
using Microsoft.AspNetCore.Mvc;
using MovieMaker.Application.Features.Movies.Commands;
using MovieMaker.Application.Features.Movies.Queries;
using MovieMaker.Domain.Features.Movies;
using MovieMaker.Web.Api.Base;
using MovieMaker.Web.Api.Controllers.Movies.ViewModels;
using System.Threading.Tasks;

namespace MovieMaker.Web.Api.Controllers.Movies
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : WebApiBaseController
    {

        private readonly IMediator _mediator;

        public MoviesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Lista todos os filmes
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var movieGetAllQuery = new MovieGetAllQuery();
            return HandleQueryable<Movie, MoviesGetAllViewModel>(await _mediator.Send(movieGetAllQuery));            
        }

        /// <summary>
        /// Busca um filme pelo id
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var movieGetByIdQuery = new MovieGetByIdQuery { Id = id };
            return HandleQuery<Movie, MoviesGetByIdViewModel>(await _mediator.Send(movieGetByIdQuery));
        }

        /// <summary>
        /// Cria um novo filme
        /// </summary>
        /// <param name="movieCreateCommand"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] MovieCreateCommand movieCreateCommand)
        {
            return HandleCommand(await _mediator.Send(movieCreateCommand));
        }

        /// <summary>
        /// Atualiza um filme
        /// </summary>
        /// <param name="movieUpdateCommand"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] MovieUpdateCommand movieUpdateCommand)
        {
            return HandleCommand(await _mediator.Send(movieUpdateCommand));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] MovieDeleteCommand movieDeleteCommand)
        {
            return HandleCommand(await _mediator.Send(movieDeleteCommand));
        }

    }
}
