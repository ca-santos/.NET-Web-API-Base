using MovieMaker.Infra.Shared;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MovieMaker.Domain.Features.Rentals
{
    public interface IRentalRepository
    {

        Response<Exception, IQueryable<Rental>> GetAll();

        Task<Response<Exception, Rental>> GetByIdAsync(int id);

        Response<Exception, IQueryable<Rental>> GetByCustomerCPF(string cpf);

        Task<Response<Exception, Rental>> CreateAsync(Rental rental);

        Task<Response<Exception, Rental>> UpdateAsync(Rental rental);

    }
}
