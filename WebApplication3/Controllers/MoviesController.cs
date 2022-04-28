using Microsoft.AspNetCore.Mvc;
using WebApplication3.Data;
using WebApplication3.Data.Interfaces;
using WebApplication3.ViewModels;
using System.Linq;
using System.Collections.Generic;
using WebApplication3.Data.Models;
using System;

namespace WebApplication3.Controllers
{
    public class MoviesController : Controller
    {
        // возвращает хтмл страничку
        private readonly IAllMovies _allMovies;
        private readonly IAllActors _allActors;
        private readonly AppDBContent appDBContent;

        public MoviesController(IAllMovies iAllMovies, IAllActors iAllActors, AppDBContent appDBContent)
        {
            _allMovies = iAllMovies;
            _allActors = iAllActors;
            this.appDBContent = appDBContent;
        }
        [Route("Movies/List")]
        [Route("Movies/List/{SortBy}")]
        public ViewResult List(string Sort)
        {
            ViewBag.Title = "фильмы";
            IEnumerable<Movie> Movies = null;
            string Sorted = "";

            if(string.Equals(("Alphabet"), Sort, StringComparison.OrdinalIgnoreCase))
            {
                Movies = _allMovies.Movies.OrderByDescending(m => m.Name);
                Sorted = "По алфавиту";
            }
            else if(string.Equals(("Release"), Sort, StringComparison.OrdinalIgnoreCase))
            {
                Movies = _allMovies.Movies.OrderByDescending(m => m.Release);
                Sorted = "По выходу в прокат";
            }
            else if (string.IsNullOrWhiteSpace(Sort) || string.Equals(("MostPopular"), Sort, StringComparison.OrdinalIgnoreCase))
            {
                Movies = _allMovies.Movies.OrderByDescending(m => m.Rating);
                Sorted = "По рейтингу";
            }
            MoviesListViewModel obj = new MoviesListViewModel
            {
                AllMovies = Movies,
                Sorted = Sorted,
            };

            return View(obj);
        }
        [Route("Movies/Index/{id}")]
        public ViewResult Content(int id)
        {
            Movie movie = _allMovies.GetObjectMovie(id);
            ViewBag.Title = movie.Name;
            var movie_obj = new MovieListViewModel
            {
                Movie = movie,
                AllActors = new List<Actor>()
            };
            return View(movie_obj);
        }
    }
}
