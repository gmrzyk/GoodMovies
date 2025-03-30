using System.Collections.Generic;
using Project.Models;

namespace Project.Services
{
    public static class MovieService
    {
        public static List<Movie> GetSampleMovies()
        {
            return new List<Movie>
            {
                new Movie { Title = "Incepcja", Genre = "Sci-Fi", Director = "Christopher Nolan", Year = 2010, Rating = 8.8 },
                new Movie { Title = "Interstellar", Genre = "Sci-Fi", Director = "Christopher Nolan", Year = 2014, Rating = 8.6 },
                new Movie { Title = "Fight Club", Genre = "Dramat", Director = "David Fincher", Year = 1999, Rating = 8.8 }
            };
        }
    }
}