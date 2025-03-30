using System.Collections.ObjectModel;
using System.Windows.Input;
using Project.Models;
using Project.Services;

namespace Project.ViewModels
{
    public class MovieListViewModel
    {
        public ObservableCollection<Movie> Movies { get; set; }
        public Movie SelectedMovie { get; set; }
        public ICommand AddMovieCommand { get; }
        public ICommand RemoveMovieCommand { get; }

        public MovieListViewModel()
        {
            Movies = new ObservableCollection<Movie>(MovieService.GetSampleMovies());
            AddMovieCommand = new RelayCommand(AddMovie);
            RemoveMovieCommand = new RelayCommand(RemoveMovie, CanRemoveMovie);
        }

        private void AddMovie()
        {
            Movies.Add(new Movie { Title = "Nowy Film", Genre = "Nieznany", Director = "Nieznany", Year = 2024, Rating = 0 });
        }

        private void RemoveMovie()
        {
            if (SelectedMovie != null)
                Movies.Remove(SelectedMovie);
        }

        private bool CanRemoveMovie() => SelectedMovie != null;
    }
}