using System.Collections.Generic;
using WebApplication3.Data.Models;

namespace WebApplication3.ViewModels
{
    public class MovieListViewModel
    {
        public Movie Movie { get; set; }
        public List<Actor> AllActors { get; set; }
    }
}
