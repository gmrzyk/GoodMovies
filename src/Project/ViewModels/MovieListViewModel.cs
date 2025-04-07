using System.Collections.ObjectModel;
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
        
        public ObservableCollection<Movie> Movies { get; } = new ObservableCollection<Movie>();
        
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
            Movies.Clear();
            
            var sampleMovies = new List<Movie>
            {
                new Movie 
                {
                    Title = "Incepcja",
                    Director = "Christopher Nolan", 
                    Year = 2010,
                    Description = "Złodziej, który potrafi wykradać sekrety z podświadomości podczas snu.",
                    PosterUrl = "https://m.media-amazon.com/images/M/MV5BMjAxMzY3NjcxNF5BMl5BanBnXkFtZTcwNTI5OTM0Mw@@._V1_FMjpg_UX1000_.jpg",
                    Genre = "Sci-Fi",
                    Rating = 8.8 
                },
                new Movie 
                {
                    Title = "Matrix",
                    Director = "Lana i Lilly Wachowski", 
                    Year = 1999,
                    Description = "Haker komputerowy dowiaduje się od tajemniczych rebeliantów o prawdziwej naturze swojej rzeczywistości.",
                    PosterUrl = "https://m.media-amazon.com/images/M/MV5BNzQzOTk3OTAtNDQ0Zi00ZTVkLWI0MTEtMDllZjNkYzNjNTc4L2ltYWdlXkEyXkFqcGdeQXVyNjU0OTQ0OTY@._V1_.jpg",
                    Genre = "Sci-Fi",
                    Rating = 8.7 
                },
                new Movie 
                {
                    Title = "Skazani na Shawshank",
                    Director = "Frank Darabont", 
                    Year = 1994,
                    Description = "Dwóch więźniów nawiązuje więź, znajdując pocieszenie i ostateczne odkupienie przez aktów wspólnej łaski.",
                    PosterUrl = "https://m.media-amazon.com/images/M/MV5BNDE3ODcxYzMtY2YzZC00NmNlLWJiNDMtZDViZWM2MzIxZDYwXkEyXkFqcGdeQXVyNjAwNDUxODI@._V1_FMjpg_UX1000_.jpg",
                    Genre = "Dramat",
                    Rating = 9.3 
                }
            };

            foreach (var movie in sampleMovies)
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