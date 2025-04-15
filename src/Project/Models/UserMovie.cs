namespace Project.Models
{
    public class UserMovie : Movie
    {
        public UserMovie() { }

        public UserMovie(Movie movie)
        {
            Title = movie.Title;
            Director = movie.Director;
            Year = movie.Year;
            Description = movie.Description;
            PosterUrl = movie.PosterUrl;
            Genre = movie.Genre;
            Rating = movie.Rating;
            IsFavorite = false;
            IsWatched = false;
            ToWatch = false;
        }

        public bool IsFavorite { get; set; }
        public bool IsWatched { get; set; }
        public bool ToWatch { get; set; }

        public void UpdateFrom(Movie movie)
        {
            Director = movie.Director;
            Year = movie.Year;
            Description = movie.Description;
            PosterUrl = movie.PosterUrl;
            Genre = movie.Genre;
            Rating = movie.Rating;
        }
    }
}