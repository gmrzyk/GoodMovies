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
    public class MovieCollectionViewModel : BaseViewModel
    {
        private readonly MovieService _movieService;
        private readonly NavigationService _navigationService;
        private string _searchQuery;
        private ObservableCollection<UserMovie> _allMovies = new ObservableCollection<UserMovie>();
        private string _title;
        private string _collectionType;

        public ObservableCollection<UserMovie> Movies { get; } = new ObservableCollection<UserMovie>();
        
        public string Title
        {
            get => _title;
            private set => SetField(ref _title, value);
        }
        
        public string CollectionType
        {
            get => _collectionType;
            private set => SetField(ref _collectionType, value);
        }
        
        public string SearchQuery
        {
            get => _searchQuery;
            set
            {
                SetField(ref _searchQuery, value);
                FilterMovies();
            }
        }

        public ICommand NavigateBackCommand { get; }
        public ICommand MoveToWatchedCommand { get; }
        public ICommand AddToFavoritesCommand { get; }
        public ICommand RemoveFromWatchedCommand { get; }
        public ICommand RemoveFromFavoritesCommand { get; }
        public ICommand RemoveFromWatchListCommand { get; }
        public ICommand ShowMovieDetailsCommand { get; }

        public MovieCollectionViewModel(MovieService movieService, NavigationService navigationService)
        {
            _movieService = movieService;
            _navigationService = navigationService;
            
            NavigateBackCommand = new RelayCommand(NavigateBack);
            MoveToWatchedCommand = new RelayCommand<UserMovie>(MoveToWatched);
            AddToFavoritesCommand = new RelayCommand<UserMovie>(AddToFavorites);
            RemoveFromWatchedCommand = new RelayCommand<UserMovie>(RemoveFromWatched);
            RemoveFromFavoritesCommand = new RelayCommand<UserMovie>(RemoveFromFavorites);
            RemoveFromWatchListCommand = new RelayCommand<UserMovie>(RemoveFromWatchList);
            ShowMovieDetailsCommand = new RelayCommand<UserMovie>(ShowMovieDetails);
        }

        public void Initialize(string collectionType)
        {
            CollectionType = collectionType;
            
            switch (collectionType)
            {
                case "Favorites":
                    Title = "Ulubione filmy";
                    _allMovies = new ObservableCollection<UserMovie>(_movieService.GetFavorites());
                    break;
                case "Watched":
                    Title = "Obejrzane filmy";
                    _allMovies = new ObservableCollection<UserMovie>(_movieService.GetWatched());
                    break;
                case "ToWatch":
                    Title = "Do obejrzenia";
                    _allMovies = new ObservableCollection<UserMovie>(_movieService.GetWatchList());
                    break;
            }
            FilterMovies();
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

        private void NavigateBack()
        {
            _navigationService.NavigateTo<MovieListViewModel>();
        }

        private void MoveToWatched(UserMovie movie)
        {
            _movieService.MoveToWatched(movie);
            _allMovies.Remove(movie);
            FilterMovies();
            MessageBox.Show($"Dodano '{movie.Title}' do obejrzanych i usunięto z listy do obejrzenia!");
        }

        private void AddToFavorites(UserMovie movie)
        {
            _movieService.AddToFavorites(movie);
            
            if (CollectionType == "ToWatch")
            {
                _movieService.RemoveFromWatchList(movie);
                _allMovies.Remove(movie);
            }
    
            FilterMovies();
            MessageBox.Show($"Dodano '{movie.Title}' do ulubionych!");
        }

        private void RemoveFromWatched(UserMovie movie)
        {
            _movieService.RemoveFromWatched(movie);
            _allMovies.Remove(movie);
            FilterMovies();
            MessageBox.Show($"Usunięto '{movie.Title}' z obejrzanych!");
        }

        private void RemoveFromFavorites(UserMovie movie)
        {
            _movieService.RemoveFromFavorites(movie);
            _allMovies.Remove(movie);
            FilterMovies();
            MessageBox.Show($"Usunięto '{movie.Title}' z ulubionych!");
        }

        private void RemoveFromWatchList(UserMovie movie)
        {
            _movieService.RemoveFromWatchList(movie);
            _allMovies.Remove(movie);
            FilterMovies();
            MessageBox.Show($"Usunięto '{movie.Title}' z listy do obejrzenia!");
        }

        private void ShowMovieDetails(UserMovie movie)
        {
            _navigationService.NavigateTo<MovieDetailsViewModel>(movie);
        }
    }
}