using System.Windows;
using System.Windows.Controls;
using Microsoft.Extensions.DependencyInjection;
using Project.ViewModels;

namespace Project.UserControls
{
    public partial class Sidebar : UserControl
    {
        public Sidebar()
        {
            InitializeComponent();
            DataContext = ((App)Application.Current).ServiceProvider.GetRequiredService<MainViewModel>();
        }
    }
}