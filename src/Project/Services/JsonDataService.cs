using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Project.Models;

namespace Project.Services
{
    public class JsonDataService
    {
        private readonly string _dataDirectory;
        private const string MoviesFile = "movies.json";
        private const string UserMoviesFile = "usermovies.json";

        public JsonDataService()
        {
            _dataDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "Data");
            
            if (!Directory.Exists(_dataDirectory))
            {
                Directory.CreateDirectory(_dataDirectory);
            }

            // Inicjalizacja tylko pustego pliku dla UserMovies
            var userMoviesPath = Path.Combine(_dataDirectory, UserMoviesFile);
            if (!File.Exists(userMoviesPath))
            {
                File.WriteAllText(userMoviesPath, "[]");
            }
        }

        public List<Movie> LoadMovies()
        {
            var path = Path.Combine(_dataDirectory, MoviesFile);
            if (!File.Exists(path)) return new List<Movie>();

            var json = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<List<Movie>>(json) ?? new List<Movie>();
        }

        public void SaveMovies(List<Movie> movies)
        {
            var path = Path.Combine(_dataDirectory, MoviesFile);
            var json = JsonConvert.SerializeObject(movies, Formatting.Indented);
            File.WriteAllText(path, json);
        }

        public List<UserMovie> LoadUserMovies()
        {
            var path = Path.Combine(_dataDirectory, UserMoviesFile);
            if (!File.Exists(path)) return new List<UserMovie>();

            var json = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<List<UserMovie>>(json) ?? new List<UserMovie>();
        }

        public void SaveUserMovies(List<UserMovie> userMovies)
        {
            var path = Path.Combine(_dataDirectory, UserMoviesFile);
            var json = JsonConvert.SerializeObject(userMovies, Formatting.Indented);
            File.WriteAllText(path, json);
        }
    }
}