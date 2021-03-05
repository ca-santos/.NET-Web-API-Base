using MediatR;
using Microsoft.AspNetCore.Mvc;
using MovieMaker.Web.Api.Controllers.Genres.ViewModels;
using System.Threading.Tasks;
using MovieMaker.Domain.Features.Genres;
using MovieMaker.Web.Api.Base;
using MovieMaker.Application.Features.Genres.Queries;
using MovieMaker.Application.Features.Genres.Commands;

namespace MovieMaker.Web.Api.Controllers.Genres
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : WebApiBaseController
    {

        private readonly IMediator _mediator;

        public GenresController(IMediator mediator)
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
            var genreGetAllQuery = new GenreGetAllQuery();
            return HandleQueryable<Genre, GenresGetAllViewModel>(await _mediator.Send(genreGetAllQuery));           
        }

        /// <summary>
        /// Busca um filme pelo id
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var genreGetByIdQuery = new GenreGetByIdQuery { Id = id };
            return HandleQuery<Genre, GenresGetByIdViewModel>(await _mediator.Send(genreGetByIdQuery));
        }

        /// <summary>
        /// Cria um novo filme
        /// </summary>
        /// <param name="genreCreateCommand"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] GenreCreateCommand genreCreateCommand)
        {
            return HandleCommand(await _mediator.Send(genreCreateCommand));
        }

        /// <summary>
        /// Atualiza um filme
        /// </summary>
        /// <param name="genreUpdateCommand"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] GenreUpdateCommand genreUpdateCommand)
        {
            return HandleCommand(await _mediator.Send(genreUpdateCommand));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] GenreDeleteCommand genreDeleteCommand)
        {
            return HandleCommand(await _mediator.Send(genreDeleteCommand));
        }

    }
}
