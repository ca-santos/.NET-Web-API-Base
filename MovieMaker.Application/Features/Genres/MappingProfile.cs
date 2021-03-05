using AutoMapper;
using MovieMaker.Application.Features.Genres.Commands;
using MovieMaker.Domain.Features.Genres;

namespace MovieMaker.Application.Features.Genres
{
    class MappingProfile : Profile
    {

        public MappingProfile()
        {

            CreateMap<GenreCreateCommand, Genre>();

            CreateMap<GenreUpdateCommand, Genre>();

        }

    }
}
