using System;

namespace MovieMaker.Web.Api.Controllers.Genres.ViewModels
{

    public class GenresGetByIdViewModel
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime CreatedAt { get; set; }

        public bool Active { get; set; }

    }

}
