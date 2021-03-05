using AutoMapper;
using MovieMaker.Application.Features.Rentals.Commands;
using MovieMaker.Domain.Features.Rentals;

namespace MovieMaker.Application.Features.Rentals
{
    class MappingProfile : Profile
    {

        public MappingProfile()
        {

            CreateMap<RentalCreateCommand, Rental>();

            CreateMap<RentalUpdateCommand, Rental>()
                .ForMember(x => x.RentedAt, opt => opt.Ignore()); ;

        }

    }
}
