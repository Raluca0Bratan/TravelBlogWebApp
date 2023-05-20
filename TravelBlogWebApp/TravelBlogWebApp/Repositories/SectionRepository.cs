using TravelBlogWebApp.Models;
using TravelBlogWebApp.Repositories.Interfaces;


namespace TravelBlogWebApp.Repositories
{
    public class SectionRepository : BaseRepository<Section>, ISectionRepository
    {
        public SectionRepository(TravelBlogDbContext context) : base(context)
        {
        }
    }
}
