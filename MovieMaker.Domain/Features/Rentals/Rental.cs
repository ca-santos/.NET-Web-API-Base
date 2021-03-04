using MovieMaker.Domain.DomainObjects;
using MovieMaker.Domain.Features.Movies;
using System;
using System.Collections.Generic;

namespace MovieMaker.Domain.Features.Rentals
{
    public class Rental : Entity
    {

        public List<Movie> Movies { get; set; }

        public string CustomerCPF { get; set; }

        public DateTime RentedOn { get; set; }

    }
}
