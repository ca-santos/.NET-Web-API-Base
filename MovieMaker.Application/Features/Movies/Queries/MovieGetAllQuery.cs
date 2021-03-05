using MediatR;
using MovieMaker.Domain.Features.Movies;
using MovieMaker.Infra.Shared;
using System;
using System.Linq;

namespace MovieMaker.Application.Features.Movies.Queries
{
    public class MovieGetAllQuery : IRequest<Response<Exception, IQueryable<Movie>>>
    {
    }
}
