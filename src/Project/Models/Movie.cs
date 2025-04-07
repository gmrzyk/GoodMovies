namespace Project.Models
{
    public class Movie
    {
        public string Title { get; set; }
        public string Director { get; set; }
        public int Year { get; set; }
        public string Description { get; set; }
        public string PosterUrl { get; set; }
        public string Genre { get; set; }
        public double Rating { get; set; }
    }
}