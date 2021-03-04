using AutoMapper;
using MovieMaker.Application.Features.Movies.Commands;
using MovieMaker.Domain.Features.Movies;

namespace MovieMaker.Application.Features.Movies
{
    class MappingProfile : Profile
    {

        public MappingProfile()
        {

            CreateMap<MovieCreateCommand, Movie>()
                .ForMember(m => m.Genre, opt => opt.Ignore())
                .ForMember(m => m.GenreId, opt => opt.Ignore());

        }

    }
}
