using MediatR;
using Microsoft.AspNetCore.Mvc;
using MovieMaker.Web.Api.Controllers.Rentals.ViewModels;
using System.Threading.Tasks;
using MovieMaker.Domain.Features.Rentals;
using MovieMaker.Web.Api.Base;
using MovieMaker.Application.Features.Rentals.Queries;
using MovieMaker.Application.Features.Rentals.Commands;
using System.Collections.Generic;

namespace MovieMaker.Web.Api.Controllers.Rentals
{

    /// <summary>
    /// Manipula a feature de aluguel de filmes
    /// </summary>
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
        /// Lista todos os alugueis
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<RentalsGetAllViewModel>))]
        [ProducesResponseType(400, Type = typeof(ExceptionBase))]
        [ProducesResponseType(500, Type = typeof(ExceptionBase))]
        public async Task<IActionResult> GetAll()
        {
            var rentalGetAllQuery = new RentalGetAllQuery();
            return HandleQueryable<Rental, RentalsGetAllViewModel>(await _mediator.Send(rentalGetAllQuery));           
        }

        /// <summary>
        /// Busca um aluguel pelo id
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(RentalsGetByIdViewModel))]
        [ProducesResponseType(400, Type = typeof(ExceptionBase))]
        [ProducesResponseType(500, Type = typeof(ExceptionBase))]
        public async Task<IActionResult> GetById(int id)
        {
            var rentalGetByIdQuery = new RentalGetByIdQuery { Id = id };
            return HandleQuery<Rental, RentalsGetByIdViewModel>(await _mediator.Send(rentalGetByIdQuery));
        }

        /// <summary>
        /// Lista todos os alugueis pelo cpf do cliente
        /// </summary>
        /// <param name="cpf"></param>
        /// <returns></returns>
        [HttpGet("{customerCpf}")]
        [ProducesResponseType(200, Type = typeof(List<RentalsGetByCustomerCpf>))]
        [ProducesResponseType(400, Type = typeof(ExceptionBase))]
        [ProducesResponseType(500, Type = typeof(ExceptionBase))]
        public async Task<IActionResult> GetByCustomerCpf(string cpf)
        {
            var rentalGetByCustomerCpfQuery = new RentalGetByCustomerCpfQuery { Cpf = cpf };
            return HandleQueryable<Rental, RentalsGetByCustomerCpf>(await _mediator.Send(rentalGetByCustomerCpfQuery));
        }

        /// <summary>
        /// Cria um novo aluguel
        /// </summary>
        /// <param name="rentalCreateCommand"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(Rental))]
        [ProducesResponseType(400, Type = typeof(ExceptionBase))]
        [ProducesResponseType(500, Type = typeof(ExceptionBase))]
        public async Task<IActionResult> Create([FromBody] RentalCreateCommand rentalCreateCommand)
        {
            return HandleCommand(await _mediator.Send(rentalCreateCommand));
        }

        /// <summary>
        /// Atualiza um aluguel
        /// </summary>
        /// <param name="rentalUpdateCommand"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(200, Type = typeof(Rental))]
        [ProducesResponseType(400, Type = typeof(ExceptionBase))]
        [ProducesResponseType(500, Type = typeof(ExceptionBase))]
        public async Task<IActionResult> Update([FromBody] RentalUpdateCommand rentalUpdateCommand)
        {
            return HandleCommand(await _mediator.Send(rentalUpdateCommand));
        }

        /// <summary>
        /// Finaliza um aluguel
        /// </summary>
        /// <param name="rentalFinishCommand"></param>
        /// <returns></returns>
        [HttpPut("Finish")]
        [ProducesResponseType(200, Type = typeof(Rental))]
        [ProducesResponseType(400, Type = typeof(ExceptionBase))]
        [ProducesResponseType(500, Type = typeof(ExceptionBase))]
        public async Task<IActionResult> FinishRental([FromBody] RentalFinishCommand rentalFinishCommand)
        {
            return HandleCommand(await _mediator.Send(rentalFinishCommand));
        }

    }
}
