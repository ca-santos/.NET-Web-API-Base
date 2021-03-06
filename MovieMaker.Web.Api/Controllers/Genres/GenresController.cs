using MediatR;
using Microsoft.AspNetCore.Mvc;
using MovieMaker.Web.Api.Controllers.Genres.ViewModels;
using System.Threading.Tasks;
using MovieMaker.Domain.Features.Genres;
using MovieMaker.Web.Api.Base;
using MovieMaker.Application.Features.Genres.Queries;
using MovieMaker.Application.Features.Genres.Commands;
using System.Collections.Generic;
using MovieMaker.Infra.Shared;

namespace MovieMaker.Web.Api.Controllers.Genres
{
    /// <summary>
    /// Manipula a feature de gêneros de filmes
    /// </summary>
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
        /// Lista todos os gêneros
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<GenresGetAllViewModel>))]
        [ProducesResponseType(400, Type = typeof(ExceptionBase))]
        [ProducesResponseType(500, Type = typeof(ExceptionBase))]
        public async Task<IActionResult> GetAll()
        {
            var genreGetAllQuery = new GenreGetAllQuery();
            return HandleQueryable<Genre, GenresGetAllViewModel>(await _mediator.Send(genreGetAllQuery));           
        }

        /// <summary>
        /// Busca um gênero pelo id
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(GenresGetByIdViewModel))]
        [ProducesResponseType(400, Type = typeof(ExceptionBase))]
        [ProducesResponseType(500, Type = typeof(ExceptionBase))]
        public async Task<IActionResult> GetById(int id)
        {
            var genreGetByIdQuery = new GenreGetByIdQuery { Id = id };
            return HandleQuery<Genre, GenresGetByIdViewModel>(await _mediator.Send(genreGetByIdQuery));
        }

        /// <summary>
        /// Cria um novo gênero
        /// </summary>
        /// <param name="genreCreateCommand"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(Genre))]
        [ProducesResponseType(400, Type = typeof(ExceptionBase))]
        [ProducesResponseType(500, Type = typeof(ExceptionBase))]
        public async Task<IActionResult> Create([FromBody] GenreCreateCommand genreCreateCommand)
        {
            return HandleCommand(await _mediator.Send(genreCreateCommand));
        }

        /// <summary>
        /// Atualiza um gênero
        /// </summary>
        /// <param name="genreUpdateCommand"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(200, Type = typeof(Genre))]
        [ProducesResponseType(400, Type = typeof(ExceptionBase))]
        [ProducesResponseType(500, Type = typeof(ExceptionBase))]
        public async Task<IActionResult> Update([FromBody] GenreUpdateCommand genreUpdateCommand)
        {
            return HandleCommand(await _mediator.Send(genreUpdateCommand));
        }

        /// <summary>
        /// Remove um gênero
        /// </summary>
        /// <param name="genreDeleteCommand"></param>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType(200, Type = typeof(AppUnit))]
        [ProducesResponseType(400, Type = typeof(ExceptionBase))]
        [ProducesResponseType(500, Type = typeof(ExceptionBase))]
        public async Task<IActionResult> Delete([FromBody] GenreDeleteCommand genreDeleteCommand)
        {
            return HandleCommand(await _mediator.Send(genreDeleteCommand));
        }

    }
}
