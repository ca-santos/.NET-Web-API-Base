using MovieMaker.Domain.DomainObjects;
using MovieMaker.Domain.Features.Genres;
using MovieMaker.Domain.Features.Rentals;
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

        public virtual int? ActiveRentalId { get; set; }

        public virtual Rental ActiveRental { get; set; }

        public void SetGenre(Genre genre)
        {
            Genre = genre;
        }

        public bool IsRented()
        {
            return ActiveRentalId != null;
        }

    }
}
