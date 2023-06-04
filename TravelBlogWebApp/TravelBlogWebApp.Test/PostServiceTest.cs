using Moq;
using System.Linq.Expressions;
using TravelBlogWebApp.Models;
using TravelBlogWebApp.Repositories.Interfaces;
using TravelBlogWebApp.ServicesFolder;

namespace TravelBlogWebApp.Test
{
    [TestClass]
    public class PostServiceTests
    {
        private Mock<IRepositoryWrapper> mockRepositoryWrapper;
        private PostService postService;
        private Mock<IPostRepository> mockPostRepository;
        private Mock<IBlogRepository> mockBlogRepository;
        private Mock<IDestinationRepository> mockDestinationRepository;
        private Mock<IUserRepository> mockUserRepository;
        private Mock<ISectionRepository> mockSectionRepository;
        private Mock<ICommentRepository> mockCommentRepository;
        private Mock<TravelBlogDbContext> mockDbContext;

        [TestInitialize]
        public void Setup()
        {
            mockDbContext = new Mock<TravelBlogDbContext>();
            mockRepositoryWrapper = new Mock<IRepositoryWrapper>();
            mockPostRepository = new Mock<IPostRepository>();
            mockBlogRepository = new Mock<IBlogRepository>();
            mockDestinationRepository = new Mock<IDestinationRepository>();
            mockUserRepository = new Mock<IUserRepository>();   
            mockSectionRepository = new Mock<ISectionRepository>(); 
            mockCommentRepository = new Mock<ICommentRepository>();

            mockRepositoryWrapper = new Mock<IRepositoryWrapper>();

            mockRepositoryWrapper.Setup(w=>w.PostRepository).Returns(mockPostRepository.Object);    
            postService = new PostService(mockRepositoryWrapper.Object);
        }

        [TestMethod]
        public void FindAll_ReturnsAllPosts()
        {
            // Arrange
            var expectedPosts = new List<Post>()
        {
            new Post { Id = 1, Title = "Post 1" },
            new Post { Id = 2, Title = "Post 2" },
        };
            mockPostRepository.Setup(r => r.FindAll()).Returns(expectedPosts.AsQueryable());

            // Act
            var result = postService.FindAll();

            // Assert
            Assert.AreEqual(expectedPosts.Count, result.Count());
            CollectionAssert.AreEqual(expectedPosts, result.ToList());
        }

        [TestMethod]
        public void FindByCondition_ReturnsFilteredPosts()
        {
            // Arrange
            var posts = new List<Post>()
    {
        new Post { Id = 1, Title = "Post 1", DateTime = DateTime.Now, LikesNumber = 10 },
        new Post { Id = 2, Title = "Post 2", DateTime = DateTime.Now, LikesNumber = 5 },
    };
            mockPostRepository.Setup(r => r.FindByCondition(It.IsAny<Expression<Func<Post, bool>>>()))
                .Returns<Expression<Func<Post, bool>>>(expression => posts.Where(expression.Compile()).AsQueryable());

            // Act
            var result = postService.FindByCondition(p => p.LikesNumber > 5);

            // Assert
            Assert.AreEqual(1, result.Count());
            Assert.AreEqual(posts[0], result.First());
        }

        [TestMethod]
        public void Create_CallsPostRepositoryCreateAndSave()
        {
            // Arrange
            var post = new Post { Id = 1, Title = "New Post" };

            // Act
            postService.Create(post);

            // Assert
            mockPostRepository.Verify(r => r.Create(post), Times.Once);
            mockRepositoryWrapper.Verify(r => r.Save(), Times.Once);
        }

        [TestMethod]
        public void Update_CallsPostRepositoryUpdateAndSave()
        {
            // Arrange
            var post = new Post { Id = 1, Title = "Updated Post" };

            // Act
            postService.Update(post);

            // Assert
            mockPostRepository.Verify(r => r.Update(post), Times.Once);
            mockRepositoryWrapper.Verify(r => r.Save(), Times.Once);
        }

        [TestMethod]
        public void Delete_CallsPostRepositoryDeleteAndSave()
        {
            // Arrange
            var post = new Post { Id = 1, Title = "Post to Delete" };

            // Act
            postService.Delete(post);

            // Assert
            mockPostRepository.Verify(r => r.Delete(post), Times.Once);
            mockRepositoryWrapper.Verify(r => r.Save(), Times.Once);
        }

        [TestMethod]
        public void GetPostWithSectionsAndComments_ReturnsPostWithSectionsAndComments()
        {
            // Arrange
            var postId = 1;
            var expectedPost = new Post { Id = postId, Title = "Post with Sections and Comments" };
            mockPostRepository.Setup(r => r.GetPostWithSectionsAndComments(postId)).Returns(expectedPost);

            // Act
            var result = postService.GetPostWithSectionsAndComments(postId);

            // Assert
            Assert.AreEqual(expectedPost, result);
        }

        [TestMethod]
        public void AddCommentToPost_CallsPostRepositoryAddCommentToPostAndSave()
        {
            // Arrange
            var postId = 1;
            var comment = new Comment { Id = 1, Content = "New Comment" };

            // Act
            postService.AddCommentToPost(postId, comment);

            // Assert
            mockPostRepository.Verify(r => r.AddCommentToPost(postId, comment), Times.Once);
            mockRepositoryWrapper.Verify(r => r.Save(), Times.Once);
        }

        [TestMethod]
        public void AddSectionToPost_CallsPostRepositoryAddSectionToPostAndSave()
        {
            // Arrange
            var postId = 1;
            var section = new Section { Id = 1, Title = "New Section" };

            // Act
            postService.AddSectionToPost(postId, section);

            // Assert
            mockPostRepository.Verify(r => r.AddSectionToPost(postId, section), Times.Once);
            mockRepositoryWrapper.Verify(r => r.Save(), Times.Once);
        }


    }
}