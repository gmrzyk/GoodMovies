using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Project.Models;
using Project.ViewModels;

namespace Project.Views
{
    public partial class MovieListView : UserControl
    {
        public MovieListView()
        {
            InitializeComponent();
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (DataContext is MovieListViewModel viewModel && ((Image)sender).DataContext is Movie movie)
            {
                viewModel.ShowMovieDetailsCommand.Execute(movie);
            }
        }

        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (DataContext is MovieListViewModel viewModel && ((TextBlock)sender).DataContext is Movie movie)
            {
                viewModel.ShowMovieDetailsCommand.Execute(movie);
            }
        }
    }
}