using MovieMaker.Domain.DomainObjects;
using MovieMaker.Domain.Features.Movies;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieMaker.Domain.Features.Rentals
{
    public class Rental : Entity
    {

        public Rental()
        {
            Movies = new List<Movie>();
        }

        public virtual List<Movie> Movies { get; set; }

        public string CustomerCPF { get; set; }

        public DateTime RentedAt { get; set; }

        public void AddMovie(Movie movie)
        {
            if (!Movies.Any(x => x.Id == movie.Id))
                Movies.Add(movie);
        }

        public void AddMovies(List<Movie> movies)
        {
            movies.ForEach(movie => AddMovie(movie));            
        }
    }
}
