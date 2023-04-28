namespace TravelBlogWebApp.Models
{
    public class Destination:ModelEntity
    {
        public string City { get; set; }
        public string Country { get; set; }
        public DateTime Date { get; set; }
        public int BlogId { get; set; }
        public int LikesNumber { get; set; }
        public Blog? Blog { get; set; }

    }
}
