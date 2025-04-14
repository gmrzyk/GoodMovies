using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Project.Models;
using Project.Services;
using Project.ViewModels;

namespace Project.ViewModels
{
    public class MovieListViewModel : BaseViewModel
    {
        private readonly MovieService _movieService;
        private readonly NavigationService _navigationService;
        private string _searchQuery;
        private ObservableCollection<Movie> _allMovies = new ObservableCollection<Movie>();

        public ObservableCollection<Movie> Movies { get; } = new ObservableCollection<Movie>();
        
        public string SearchQuery
        {
            get => _searchQuery;
            set
            {
                SetField(ref _searchQuery, value);
                FilterMovies();
            }
        }

        public ICommand AddToFavoritesCommand { get; }
        public ICommand AddToWatchedCommand { get; }
        public ICommand AddToWatchListCommand { get; }
        public ICommand ShowMovieDetailsCommand { get; }

        public MovieListViewModel(MovieService movieService, NavigationService navigationService)
        {
            _movieService = movieService;
            _navigationService = navigationService;
            
            LoadMovies();
            
            AddToFavoritesCommand = new RelayCommand<Movie>(AddToFavorites);
            AddToWatchedCommand = new RelayCommand<Movie>(AddToWatched);
            AddToWatchListCommand = new RelayCommand<Movie>(AddToWatchList);
            ShowMovieDetailsCommand = new RelayCommand<Movie>(ShowMovieDetails);
        }

        private void LoadMovies()
        {
            _allMovies = new ObservableCollection<Movie>(_movieService.GetAllMovies());
            FilterMovies();

            if (!_allMovies.Any())
            {
                MessageBox.Show("Brak filmów w bazie danych. Dodaj filmy do pliku Data/movies.json");
            }
        }

        private void FilterMovies()
        {
            Movies.Clear();
            var filtered = string.IsNullOrWhiteSpace(SearchQuery)
                ? _allMovies
                : _allMovies.Where(m => m.Title.Contains(SearchQuery, StringComparison.OrdinalIgnoreCase));

            foreach (var movie in filtered)
            {
                Movies.Add(movie);
            }
        }

        private void AddToFavorites(Movie movie)
        {
            _movieService.AddToFavorites(movie);
            MessageBox.Show($"Dodano {movie.Title} do ulubionych!");
        }

        private void AddToWatched(Movie movie)
        {
            _movieService.AddToWatched(movie);
            MessageBox.Show($"Dodano {movie.Title} do obejrzanych!");
        }

        private void AddToWatchList(Movie movie)
        {
            _movieService.AddToWatchList(movie);
            MessageBox.Show($"Dodano {movie.Title} do listy do obejrzenia!");
        }

        private void ShowMovieDetails(Movie movie)
        {
            _navigationService.NavigateTo<MovieDetailsViewModel>(movie);
        }
    }
}