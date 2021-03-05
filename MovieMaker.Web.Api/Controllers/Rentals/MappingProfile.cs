using AutoMapper;
using MovieMaker.Domain.Features.Movies;
using MovieMaker.Domain.Features.Rentals;
using MovieMaker.Web.Api.Controllers.Rentals.ViewModels;

namespace MovieMaker.Web.Api.Controllers.Rentals
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {

            CreateMap<Rental, RentalsGetAllViewModel>();

        }

    }
}
