using MediatR;
using MovieMaker.Domain.Features.Genres;
using MovieMaker.Infra.Shared;
using System;
using System.Linq;

namespace MovieMaker.Application.Features.Genres.Queries
{
    public class GenreGetAllQuery : IRequest<Response<Exception, IQueryable<Genre>>>
    {
    }
}
