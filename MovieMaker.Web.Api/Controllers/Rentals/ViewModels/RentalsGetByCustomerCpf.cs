using MovieMaker.Domain.Features.Movies;
using System;
using System.Collections.Generic;

namespace MovieMaker.Web.Api.Controllers.Rentals.ViewModels
{

    public class RentalsGetByIdViewModel
    {

        public int Id { get; set; }

        public string CustomerCPF { get; set; }

        public List<Movie> Movies { get; set; }

        public DateTime RentedAt { get; set; }        

    }

}
