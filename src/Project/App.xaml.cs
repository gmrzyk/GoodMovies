using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using Project.Services;
using Project.ViewModels;

namespace Project
{
    public partial class App : Application
    {
        public IServiceProvider ServiceProvider { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var services = new ServiceCollection();
            ConfigureServices(services);
            ServiceProvider = services.BuildServiceProvider();

            var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<MovieService>();
            services.AddSingleton<NavigationService>();
            
            services.AddTransient<MainViewModel>();
            services.AddTransient<MovieListViewModel>();
            services.AddTransient<MovieCollectionViewModel>();
            services.AddTransient<MovieDetailsViewModel>();
            services.AddTransient<StatisticsViewModel>();
            
            services.AddSingleton<MainWindow>();
        }
    }
}