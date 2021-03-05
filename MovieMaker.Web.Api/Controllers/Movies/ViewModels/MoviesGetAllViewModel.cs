using MovieMaker.Domain.Features.Genres;
using System;

namespace MovieMaker.Web.Api.Controllers.Movies.ViewModels
{

    public class MoviesGetAllViewModel
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime CreatedAt { get; set; }

        public bool Active { get; set; }

        public Genre Genre { get; set; }

    }

}
