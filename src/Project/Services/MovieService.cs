using System.Collections.Generic;
using System.Linq;
using Project.Models;

namespace Project.Services
{
    public class MovieService
    {
        private readonly List<UserMovie> _favorites = new();
        private readonly List<UserMovie> _watched = new();
        private readonly List<UserMovie> _toWatch = new();

        public void AddToFavorites(Movie movie)
        {
            if (!_favorites.Any(m => m.Title == movie.Title))
            {
                _favorites.Add(new UserMovie(movie) { IsFavorite = true });
            }
        }

        public void AddToWatched(Movie movie)
        {
            if (!_watched.Any(m => m.Title == movie.Title))
            {
                _watched.Add(new UserMovie(movie) { IsWatched = true });
            }
        }

        public void AddToWatchList(Movie movie)
        {
            if (!_toWatch.Any(m => m.Title == movie.Title))
            {
                _toWatch.Add(new UserMovie(movie) { ToWatch = true });
            }
        }

        public List<UserMovie> GetFavorites() => _favorites;
        public List<UserMovie> GetWatched() => _watched;
        public List<UserMovie> GetWatchList() => _toWatch;

        public void MoveToWatched(UserMovie movie)
        {
            if (!_watched.Contains(movie))
            {
                _watched.Add(movie);
            }
            movie.IsWatched = true;
            movie.ToWatch = false;
            movie.IsFavorite = false;
            _toWatch.Remove(movie);
            _favorites.Remove(movie);
        }

        public void RemoveFromFavorites(UserMovie movie)
        {
            _favorites.Remove(movie);
            movie.IsFavorite = false;
        }

        public void RemoveFromWatched(UserMovie movie)
        {
            _watched.Remove(movie);
            movie.IsWatched = false;
        }

        public void RemoveFromWatchList(UserMovie movie)
        {
            _toWatch.Remove(movie);
            movie.ToWatch = false;
        }
    }
}