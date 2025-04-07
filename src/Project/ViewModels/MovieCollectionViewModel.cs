using System.Collections.ObjectModel;
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
        
        public ObservableCollection<UserMovie> Movies { get; } = new ObservableCollection<UserMovie>();
        public string Title { get; private set; }

        public ICommand NavigateBackCommand { get; }
        public ICommand MoveToWatchedCommand { get; }
        public ICommand AddToFavoritesCommand { get; }
        public ICommand RemoveFromWatchedCommand { get; }
        public ICommand RemoveFromFavoritesCommand { get; }
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
            ShowMovieDetailsCommand = new RelayCommand<UserMovie>(ShowMovieDetails);
        }

        public void Initialize(string collectionType)
        {
            switch (collectionType)
            {
                case "Favorites":
                    Title = "Ulubione filmy";
                    LoadMovies(_movieService.GetFavorites());
                    break;
                case "Watched":
                    Title = "Obejrzane filmy";
                    LoadMovies(_movieService.GetWatched());
                    break;
                case "ToWatch":
                    Title = "Do obejrzenia";
                    LoadMovies(_movieService.GetWatchList());
                    break;
            }
        }

        private void LoadMovies(IEnumerable<UserMovie> movies)
        {
            Movies.Clear();
            foreach (var movie in movies)
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
            Movies.Remove(movie);
            MessageBox.Show($"Przeniesiono {movie.Title} do obejrzanych!");
        }

        private void AddToFavorites(UserMovie movie)
        {
            _movieService.AddToFavorites(movie);
            MessageBox.Show($"Dodano {movie.Title} do ulubionych!");
        }

        private void RemoveFromWatched(UserMovie movie)
        {
            _movieService.RemoveFromWatched(movie);
            Movies.Remove(movie);
            MessageBox.Show($"Usunięto {movie.Title} z obejrzanych!");
        }

        private void RemoveFromFavorites(UserMovie movie)
        {
            _movieService.RemoveFromFavorites(movie);
            Movies.Remove(movie);
            MessageBox.Show($"Usunięto {movie.Title} z ulubionych!");
        }

        private void ShowMovieDetails(UserMovie movie)
        {
            _navigationService.NavigateTo<MovieDetailsViewModel>(movie);
        }
    }
}