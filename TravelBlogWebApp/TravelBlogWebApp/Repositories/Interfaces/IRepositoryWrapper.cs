using TravelBlogWebApp.Models;

namespace TravelBlogWebApp.Repositories.Interfaces
{
    public interface IRepositoryWrapper
    {


        public IBlogRepository BlogRepository { get; }


        public IDestinationRepository DestinationRepository { get; }


        public IPostRepository PostRepository { get; }


        public IUserRepository UserRepository { get; }


        public ICommentRepository CommentRepository { get; }

        public ISectionRepository SectionRepository { get; }



        public void Save();
       

    }
}
