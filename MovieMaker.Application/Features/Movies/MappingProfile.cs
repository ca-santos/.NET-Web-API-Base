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
                .ForMember(m => m.Genre, opt => opt.Ignore());

            CreateMap<MovieUpdateCommand, Movie>()
                .ForMember(m => m.Genre, opt => opt.Ignore())
                .ForMember(x => x.CreatedAt, opt => opt.Ignore());

        }

    }
}
