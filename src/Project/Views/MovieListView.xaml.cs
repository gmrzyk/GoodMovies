using System.Windows.Controls;
using Project.ViewModels;

namespace Project.Views
{
    public partial class MovieListView : UserControl
    {
        public MovieListView()
        {
            InitializeComponent();
            DataContext = new MovieListViewModel();
        }
    }
}