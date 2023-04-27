namespace TravelBlogWebApp.Models
{
    public class Destination
    {
        public int DestinationID { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public DateTime Date { get; set; }
        public int BlogID { get; set; }
        public int LikesNumber { get; set; }
        public Blog? Blog { get; set; }

    }
}
