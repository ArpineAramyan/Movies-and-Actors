using System.Collections.Generic;
using WebApplication3.Data.Models;

namespace WebApplication3.ViewModels
{
    public class MoviesListViewModel
    {
        public IEnumerable<Movie> AllMovies { get; set; }
        public string Sorted { get; set; }
    }
}
