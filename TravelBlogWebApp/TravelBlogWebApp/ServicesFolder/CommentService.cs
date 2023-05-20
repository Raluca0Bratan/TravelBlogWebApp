using TravelBlogWebApp.Repositories;
using TravelBlogWebApp.ServicesFolder.Interfaces;

namespace TravelBlogWebApp.ServicesFolder
{
    public class CommentService:ICommentService
    {

        private readonly RepositoryWrapper repositoryWrapper;

        public CommentService(RepositoryWrapper repository)
        {
            this.repositoryWrapper = repository;
        }
    }
}
