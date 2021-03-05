using MediatR;
using Microsoft.AspNetCore.Mvc;
using MovieMaker.Web.Api.Controllers.Rentals.ViewModels;
using System.Threading.Tasks;
using MovieMaker.Domain.Features.Rentals;
using MovieMaker.Web.Api.Base;
using MovieMaker.Application.Features.Rentals.Queries;
using MovieMaker.Application.Features.Rentals.Commands;

namespace MovieMaker.Web.Api.Controllers.Rentals
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalsController : WebApiBaseController
    {

        private readonly IMediator _mediator;

        public RentalsController(IMediator mediator)
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
            var rentalGetAllQuery = new RentalGetAllQuery();
            return HandleQueryable<Rental, RentalsGetAllViewModel>(await _mediator.Send(rentalGetAllQuery));           
        }

        /// <summary>
        /// Busca um filme pelo id
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var rentalGetByIdQuery = new RentalGetByIdQuery { Id = id };
            return HandleQuery<Rental, RentalsGetByIdViewModel>(await _mediator.Send(rentalGetByIdQuery));
        }

        [HttpGet("{cpf}")]
        public async Task<IActionResult> GetByCustomerCpf(string cpf)
        {
            var rentalGetByCustomerCpfQuery = new RentalGetByCustomerCpfQuery { Cpf = cpf };
            return HandleQueryable<Rental, RentalsGetByCustomerCpf>(await _mediator.Send(rentalGetByCustomerCpfQuery));
        }

        /// <summary>
        /// Cria um novo filme
        /// </summary>
        /// <param name="rentalCreateCommand"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RentalCreateCommand rentalCreateCommand)
        {
            return HandleCommand(await _mediator.Send(rentalCreateCommand));
        }

        /// <summary>
        /// Atualiza um filme
        /// </summary>
        /// <param name="rentalUpdateCommand"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] RentalUpdateCommand rentalUpdateCommand)
        {
            return HandleCommand(await _mediator.Send(rentalUpdateCommand));
        }

    }
}
