using System.Collections.Generic;
using System.Linq;
using Project.Models;

namespace Project.Services
{
    public class MovieService
    {
        private readonly JsonDataService _jsonDataService;
        private List<UserMovie> _userMovies;

        public MovieService(JsonDataService jsonDataService)
        {
            _jsonDataService = jsonDataService;
            _userMovies = _jsonDataService.LoadUserMovies();
        }

        public void AddToFavorites(Movie movie)
        {
            var userMovie = _userMovies.FirstOrDefault(m => m.Title == movie.Title);
            if (userMovie == null)
            {
                userMovie = new UserMovie(movie);
                _userMovies.Add(userMovie);
            }
            userMovie.IsFavorite = true;
            userMovie.IsWatched = true;
            SaveChanges();
        }

        public void AddToWatched(Movie movie)
        {
            var userMovie = _userMovies.FirstOrDefault(m => m.Title == movie.Title);
            if (userMovie == null)
            {
                userMovie = new UserMovie(movie);
                _userMovies.Add(userMovie);
            }
            userMovie.IsWatched = true;
            SaveChanges();
        }

        public void AddToWatchList(Movie movie)
        {
            var userMovie = _userMovies.FirstOrDefault(m => m.Title == movie.Title);
            if (userMovie == null)
            {
                userMovie = new UserMovie(movie);
                _userMovies.Add(userMovie);
            }
            userMovie.ToWatch = true;
            SaveChanges();
        }

        public List<UserMovie> GetFavorites() => 
            _userMovies.Where(m => m.IsFavorite && m.IsWatched).ToList();

        public List<UserMovie> GetWatched() => 
            _userMovies.Where(m => m.IsWatched).ToList();

        public List<UserMovie> GetWatchList() => 
            _userMovies.Where(m => m.ToWatch).ToList();

        public void MoveToWatched(UserMovie movie)
        {
            movie.IsWatched = true;
            movie.ToWatch = false;
            SaveChanges();
        }

        public void RemoveFromFavorites(UserMovie movie)
        {
            movie.IsFavorite = false;
            SaveChanges();
        }

        public void RemoveFromWatched(UserMovie movie)
        {
            movie.IsWatched = false;
            movie.IsFavorite = false;
            SaveChanges();
        }

        public void RemoveFromWatchList(UserMovie movie)
        {
            movie.ToWatch = false;
            SaveChanges();
        }

        private void SaveChanges()
        {
            _jsonDataService.SaveUserMovies(_userMovies);
        }

        public List<Movie> GetAllMovies()
        {
            return _jsonDataService.LoadMovies();
        }
    }
}