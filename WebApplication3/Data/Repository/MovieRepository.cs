using System.Collections.Generic;
using WebApplication3.Data.Interfaces;
using WebApplication3.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace WebApplication3.Data.Repository
{
    public class MovieRepository : IAllMovies
    {
        private readonly AppDBContent appDBContent;
        public MovieRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }
        public IEnumerable<Movie> Movies => appDBContent.Movies.Include(c  => c.Actors); //?

        public Movie GetObjectMovie(int MovieId) => appDBContent.Movies.FirstOrDefault(p => p.Id == MovieId);
    }
}
