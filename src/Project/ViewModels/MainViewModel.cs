using Project.Services;
using Project.ViewModels;
using System.Windows.Input;

namespace Project.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly NavigationService _navigationService;
        private BaseViewModel _currentViewModel;

        public MainViewModel(NavigationService navigationService)
        {
            _navigationService = navigationService;
            _navigationService.CurrentViewModelChanged += () => CurrentViewModel = _navigationService.CurrentViewModel;
            _navigationService.NavigateTo<MovieListViewModel>();
        }

        public BaseViewModel CurrentViewModel
        {
            get => _currentViewModel;
            set => SetField(ref _currentViewModel, value);
        }

        public ICommand NavigateToCollectionCommand => new RelayCommand<string>(collectionType =>
        {
            if (collectionType == "All")
            {
                _navigationService.NavigateTo<MovieListViewModel>();
            }
            else
            {
                _navigationService.NavigateTo<MovieCollectionViewModel>(collectionType);
            }
        });
    }
}