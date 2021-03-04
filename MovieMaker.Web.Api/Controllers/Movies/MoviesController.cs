using MediatR;
using Microsoft.AspNetCore.Mvc;
using MovieMaker.Application.Features.Movies.Commands;
using MovieMaker.Web.Api.Base;
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
        public IActionResult GetAll()
        {
            //var mediator = _mediator.Send();
            return Ok();
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

    }
}
