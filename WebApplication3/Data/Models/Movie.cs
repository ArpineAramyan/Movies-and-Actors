namespace WebApplication3.Data.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string Image { get; set; }
        public string Actors { get; set; }
        public int Release { get; set; }
        public int Rating { get; set; }
    }
}
