using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Project.ViewModels;

namespace Project
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = ((App)Application.Current).ServiceProvider.GetRequiredService<MainViewModel>();
        }
    }
}