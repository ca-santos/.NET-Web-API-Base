using MovieMaker.Domain.DomainObjects;
using MovieMaker.Domain.Features.Movies;
using System;
using System.Collections.Generic;

namespace MovieMaker.Domain.Features.Genres
{
    public class Genre : Entity
    {

        public string Name { get; set; }

        public DateTime CreatedAt { get; set; }

        public bool Active { get; set; }

        public virtual List<Movie> Movies { get; set; }

    }
}
