
using TravelBlogWebApp.Models;
using TravelBlogWebApp.Repositories.Interfaces;

namespace TravelBlogWebApp.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : ModelEntity
    {
        private readonly TravelBlogDbContext context;
        public BaseRepository(TravelBlogDbContext context)
        {
            this.context = context;
        }
        public void Add(T entity)
        {
           this.context.Set<T>().Add(entity);  
           this.context.SaveChanges();
        }

        public void Delete(T entity)
        {
           this.context.Set<T>().Remove(entity);
           this.context.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return this.context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
           return this.context.Set<T>().FirstOrDefault(x => x.Id == id);
        }

        public void Update(T entity)
        {
            this.context.Set<T>().Update(entity);
            this.context.SaveChanges();
        }
    }
}
