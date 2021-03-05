using MediatR;
using MovieMaker.Domain.Features.Genres;
using MovieMaker.Infra.Shared;
using System;

namespace MovieMaker.Application.Features.Genres.Queries
{

    public class GenreGetByIdQuery : IRequest<Response<Exception, Genre>>
    {

        public int Id { get; set; }

    }

}
