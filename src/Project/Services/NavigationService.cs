using System;
using Microsoft.Extensions.DependencyInjection;
using Project.Models;
using Project.ViewModels;

namespace Project.Services
{
    public class NavigationService
    {
        private readonly IServiceProvider _serviceProvider;
        private BaseViewModel _currentViewModel;

        public NavigationService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public BaseViewModel CurrentViewModel
        {
            get => _currentViewModel;
            private set
            {
                _currentViewModel = value;
                CurrentViewModelChanged?.Invoke();
            }
        }

        public event Action CurrentViewModelChanged;

        public void NavigateTo<TViewModel>() where TViewModel : BaseViewModel
        {
            CurrentViewModel = _serviceProvider.GetRequiredService<TViewModel>();
        }

        public void NavigateTo<TViewModel>(object parameter) where TViewModel : BaseViewModel
        {
            var viewModel = _serviceProvider.GetRequiredService<TViewModel>();
            
            if (viewModel is MovieCollectionViewModel collectionViewModel && parameter is string collectionType)
            {
                collectionViewModel.Initialize(collectionType);
            }
            else if (viewModel is MovieDetailsViewModel detailsViewModel && parameter is Movie movie)
            {
                detailsViewModel.Initialize(movie);
            }
            
            CurrentViewModel = viewModel;
        }
    }
}