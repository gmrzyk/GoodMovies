using Microsoft.Extensions.DependencyInjection;
using Project.Services;
using Project.ViewModels;
using System.Windows;

namespace Project
{
    public partial class App : Application
    {
        public IServiceProvider ServiceProvider { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var resources = new ResourceDictionary();
            resources.Add("StringToVisibilityConverter", new Converters.StringToVisibilityConverter());
            resources.Add("BooleanToVisibilityConverter", new Converters.BooleanToVisibilityConverter());
            Resources.MergedDictionaries.Add(resources);

            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            ServiceProvider = serviceCollection.BuildServiceProvider();

            var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<JsonDataService>();
            services.AddSingleton<MovieService>();
            services.AddSingleton<NavigationService>();
            
            services.AddTransient<MainViewModel>();
            services.AddTransient<MovieListViewModel>();
            services.AddTransient<MovieCollectionViewModel>();
            services.AddTransient<MovieDetailsViewModel>();

            services.AddSingleton<MainWindow>();
        }
    }
}