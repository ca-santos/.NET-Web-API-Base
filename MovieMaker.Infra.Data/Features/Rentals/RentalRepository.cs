using Microsoft.EntityFrameworkCore;
using MovieMaker.Domain.Features.Rentals;
using MovieMaker.Infra.Data.Context;
using MovieMaker.Infra.Exceptions;
using MovieMaker.Infra.Shared;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MovieMaker.Infra.Data.Features.Rentals
{
    public class RentalRepository : IRentalRepository
    {

        private readonly MovieMakerDbContext _context;

        public RentalRepository(MovieMakerDbContext context)
        {
            _context = context;
        }

        public Response<Exception, IQueryable<Rental>> GetAll()
        {

            var rentals = _context.Rentals
                .Include(x => x.Movies)
                .AsNoTracking();

            return rentals.ToResponse();

        }

        public async Task<Response<Exception, Rental>> GetByIdAsync(int id)
        {

            var rental = await _context.Rentals
                .Include(x => x.Movies)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (rental == null)
                return new NotFoundException("Aluguel", id);

            return rental;

        }

        public Response<Exception, IQueryable<Rental>> GetByCustomerCPF(string cpf)
        {

            var rentals = _context.Rentals
                .Include(x => x.Movies)
                .Where(x => x.CustomerCPF.Equals(cpf))
                .AsNoTracking();

            return rentals.ToResponse();

        }

        public async Task<Response<Exception, Rental>> CreateAsync(Rental rental)
        {

            var newRental = _context.Rentals.Add(rental).Entity;

            var saveCallback = await Response.Run(() => _context.SaveChangesAsync());

            if (saveCallback.HasError)
                return saveCallback.Error;

            return newRental;

        }

        public async Task<Response<Exception, Rental>> UpdateAsync(Rental rental)
        {

            _context.Rentals.Update(rental);

            var saveCallback = await Response.Run(() => _context.SaveChangesAsync());

            if (saveCallback.HasError)
                return saveCallback.Error;

            return rental;

        }

    }
}
