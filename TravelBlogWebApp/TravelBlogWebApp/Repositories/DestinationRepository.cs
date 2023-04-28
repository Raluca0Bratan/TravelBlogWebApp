using TravelBlogWebApp.Models;
using TravelBlogWebApp.Repositories.Interfaces;

namespace TravelBlogWebApp.Repositories
{
    public class DestinationRepository : BaseRepository<Destination>, IDestinationRepository
    {
        public DestinationRepository(TravelBlogDbContext context) : base(context)
        {
        }
    }
}
