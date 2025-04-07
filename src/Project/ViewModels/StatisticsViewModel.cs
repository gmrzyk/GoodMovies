using System.Windows.Input;
using Project.Services;
using Project.ViewModels;

namespace Project.ViewModels
{
    public class StatisticsViewModel : BaseViewModel
    {
        private readonly MovieService _movieService;
        private readonly NavigationService _navigationService;

        public ICommand NavigateBackCommand { get; }

        public StatisticsViewModel(MovieService movieService, NavigationService navigationService)
        {
            _movieService = movieService;
            _navigationService = navigationService;
            NavigateBackCommand = new RelayCommand(NavigateBack);
        }

        public int FavoriteCount => _movieService.GetFavorites().Count;
        public int WatchedCount => _movieService.GetWatched().Count;
        public int ToWatchCount => _movieService.GetWatchList().Count;

        private void NavigateBack()
        {
            _navigationService.NavigateTo<MovieListViewModel>();
        }
    }
}