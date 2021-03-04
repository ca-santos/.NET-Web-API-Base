using MovieMaker.Domain.DomainObjects;
using System;

namespace MovieMaker.Domain.Features.Genres
{
    public class Genre : Entity
    {

        public string Name { get; set; }

        public DateTime CreatedAt { get; set; }

        public bool Active { get; set; }

    }
}
