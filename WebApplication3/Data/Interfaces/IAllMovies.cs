using System;
using System.Collections.Generic;
using WebApplication3.Data.Models;

namespace WebApplication3.Data.Interfaces
{
    public interface IAllMovies
    {
        IEnumerable<Movie> Movies { get; }
        Movie GetObjectMovie(int MovieId);
    }
}
