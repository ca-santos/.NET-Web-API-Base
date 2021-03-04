using MovieMaker.Domain.DomainObjects;
using MovieMaker.Domain.Features.Genres;
using System;

namespace MovieMaker.Domain.Features.Movies
{
    public class Movie : Entity
    {

        public string Name { get; set; }

        public DateTime CreatedAt { get; set; }

        public bool Active { get; set; }

        public int? GenreId { get; set; }

        public virtual Genre Genre { get; set; }

    }
}
