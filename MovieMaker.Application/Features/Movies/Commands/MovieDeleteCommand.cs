using FluentValidation;
using MediatR;
using MovieMaker.Infra.Shared;
using System;

namespace MovieMaker.Application.Features.Movies.Commands
{

    public class MovieDeleteCommand : IRequest<Response<Exception, AppUnit>>
    {

        public int Id { get; set; }

    }

}
