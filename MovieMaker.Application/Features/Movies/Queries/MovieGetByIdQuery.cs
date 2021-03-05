using MediatR;
using MovieMaker.Domain.Features.Movies;
using MovieMaker.Infra.Shared;
using System;

namespace MovieMaker.Application.Features.Movies.Queries
{

    public class MovieGetByIdQuery : IRequest<Response<Exception, Movie>>
    {

        public int Id { get; set; }

    }

}
