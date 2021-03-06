using MediatR;
using Microsoft.AspNetCore.Mvc;
using MovieMaker.Application.Features.Movies.Commands;
using MovieMaker.Application.Features.Movies.Queries;
using MovieMaker.Domain.Features.Movies;
using MovieMaker.Infra.Shared;
using MovieMaker.Web.Api.Base;
using MovieMaker.Web.Api.Controllers.Movies.ViewModels;
using System.Collections.Generic;
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
        [ProducesResponseType(200, Type = typeof(List<MoviesGetAllViewModel>))]
        [ProducesResponseType(400, Type = typeof(ExceptionBase))]
        [ProducesResponseType(500, Type = typeof(ExceptionBase))]
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
        [ProducesResponseType(200, Type = typeof(MoviesGetByIdViewModel))]
        [ProducesResponseType(400, Type = typeof(ExceptionBase))]
        [ProducesResponseType(500, Type = typeof(ExceptionBase))]
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
        [ProducesResponseType(200, Type = typeof(Movie))]
        [ProducesResponseType(400, Type = typeof(ExceptionBase))]
        [ProducesResponseType(500, Type = typeof(ExceptionBase))]
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
        [ProducesResponseType(200, Type = typeof(Movie))]
        [ProducesResponseType(400, Type = typeof(ExceptionBase))]
        [ProducesResponseType(500, Type = typeof(ExceptionBase))]
        public async Task<IActionResult> Update([FromBody] MovieUpdateCommand movieUpdateCommand)
        {
            return HandleCommand(await _mediator.Send(movieUpdateCommand));
        }

        /// <summary>
        /// Deleta um filme
        /// </summary>
        /// <param name="movieDeleteCommand"></param>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType(200, Type = typeof(AppUnit))]
        [ProducesResponseType(400, Type = typeof(ExceptionBase))]
        [ProducesResponseType(500, Type = typeof(ExceptionBase))]
        public async Task<IActionResult> Delete([FromBody] MovieDeleteCommand movieDeleteCommand)
        {
            return HandleCommand(await _mediator.Send(movieDeleteCommand));
        }

        /// <summary>
        /// Deleta múltiplos filmes
        /// </summary>
        /// <param name="movieDeleteMultipleCommand"></param>
        /// <returns></returns>
        [HttpDelete("Multiple")]
        [ProducesResponseType(200, Type = typeof(AppUnit))]
        [ProducesResponseType(400, Type = typeof(ExceptionBase))]
        [ProducesResponseType(500, Type = typeof(ExceptionBase))]
        public async Task<IActionResult> DeleteMultiple([FromBody] MovieDeleteMultipleCommand movieDeleteMultipleCommand)
        {
            return HandleCommand(await _mediator.Send(movieDeleteMultipleCommand));
        }

    }
}
