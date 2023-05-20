using TravelBlogWebApp.Models;
using TravelBlogWebApp.Repositories.Interfaces;

namespace TravelBlogWebApp.Repositories
{
    public class RepositoryWrapper
    {
        private readonly TravelBlogDbContext context;
        private IBlogRepository blogRepository;
        private IDestinationRepository destinationRepository;
        private IPostRepository postRepository;
        private IUserRepository userRepository;
        private ISectionRepository sectionRepository;
        private ICommentRepository commentRepository;   

        public RepositoryWrapper(TravelBlogDbContext context, IBlogRepository blogRepository, IDestinationRepository destinationRepository, 
            IPostRepository postRepository, IUserRepository userRepository, ICommentRepository commentRepository,ISectionRepository sectionRepository)
        {
            this.context = context;
            this.blogRepository = blogRepository;
            this.destinationRepository = destinationRepository;
            this.postRepository = postRepository;
            this.userRepository = userRepository;
            this.commentRepository = commentRepository;
            this.sectionRepository = sectionRepository; 
        }

        public IBlogRepository BlogRepository
        {
            get
            {
                if (blogRepository == null)
                {
                    blogRepository = new BlogRepository(context);
                }

                return blogRepository;
            }
        }

         public IDestinationRepository DestinationRepository
        {
            get
            {
                if (destinationRepository == null)
                {
                    destinationRepository = new DestinationRepository(context);
                }

                return destinationRepository;
            }
        }

        public IPostRepository PostRepository
        {
            get
            {
                if (postRepository == null)
                {
                    postRepository = new PostRepository(context);
                }

                return postRepository;
            }
        }

        public IUserRepository UserRepository
        {
            get
            {
                if (userRepository == null)
                {
                    userRepository = new UserRepository(context);
                }

                return userRepository;
            }
        }

        public ICommentRepository CommentRepository
        {
            get
            {
                if (commentRepository == null)
                {
                    commentRepository = new CommentRepository(context);
                }

                return commentRepository;
            }
        }
        public ISectionRepository SectionRepository
        {
            get
            {
                if (sectionRepository == null)
                {
                    sectionRepository = new SectionRepository(context);
                }

                return sectionRepository;
            }
        }


        public void Save()
        {
            context.SaveChanges();
        }

    }
}
