using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Project.ViewModels;

namespace Project.Views
{
    public partial class MovieCollectionView : UserControl
    {
        public MovieCollectionView()
        {
            InitializeComponent();
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (DataContext is MovieCollectionViewModel viewModel && 
                ((Image)sender).DataContext is Project.Models.UserMovie movie)
            {
                viewModel.ShowMovieDetailsCommand.Execute(movie);
            }
        }

        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (DataContext is MovieCollectionViewModel viewModel && 
                ((TextBlock)sender).DataContext is Project.Models.UserMovie movie)
            {
                viewModel.ShowMovieDetailsCommand.Execute(movie);
            }
        }
    }
}