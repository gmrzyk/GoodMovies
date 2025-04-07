using System.Windows.Input;
using Project.Models;
using Project.Services;
using Project.ViewModels;

namespace Project.ViewModels
{
    public class MovieDetailsViewModel : BaseViewModel
    {
        private readonly NavigationService _navigationService;
        private Movie _movie;

        public ICommand NavigateBackCommand { get; }

        public MovieDetailsViewModel(NavigationService navigationService)
        {
            _navigationService = navigationService;
            NavigateBackCommand = new RelayCommand(NavigateBack);
        }

        public Movie Movie
        {
            get => _movie;
            set => SetField(ref _movie, value);
        }

        public void Initialize(Movie movie)
        {
            Movie = movie;
        }

        private void NavigateBack()
        {
            _navigationService.NavigateTo<MovieListViewModel>();
        }
    }
}