using System.Linq;
using LiveCharts;
using LiveCharts.Wpf;
using Project.Models;
using Project.Services;

namespace Project.ViewModels
{
    public class StatisticsViewModel : BaseViewModel
    {
        private readonly MovieService _movieService;
        private double _avgRating;
        
        public int TotalFavorites => _movieService.GetFavorites().Count;
        public int TotalWatched => _movieService.GetWatched().Count;
        public int TotalToWatch => _movieService.GetWatchList().Count;
        
        public double AvgRating
        {
            get => _avgRating;
            private set => SetField(ref _avgRating, value);
        }
        
        public SeriesCollection GenreSeries { get; private set; }

        public StatisticsViewModel(MovieService movieService)
        {
            _movieService = movieService;
            InitializeChart();
            CalculateAverageRating();
        }

        private void InitializeChart()
        {
            var genreGroups = _movieService.GetWatched()
                .GroupBy(m => m.Genre)
                .Select(g => new { Genre = g.Key, Count = g.Count() })
                .OrderByDescending(g => g.Count);

            GenreSeries = new SeriesCollection();
            foreach (var group in genreGroups)
            {
                GenreSeries.Add(new PieSeries
                {
                    Title = group.Genre,
                    Values = new ChartValues<int> { group.Count },
                    DataLabels = true
                });
            }
        }

        private void CalculateAverageRating()
        {
            var watchedMovies = _movieService.GetWatched();
            AvgRating = watchedMovies.Any() ? watchedMovies.Average(m => m.Rating) : 0;
        }
    }
}