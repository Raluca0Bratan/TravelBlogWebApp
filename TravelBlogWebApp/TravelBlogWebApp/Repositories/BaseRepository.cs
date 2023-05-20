
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TravelBlogWebApp.Models;
using TravelBlogWebApp.Repositories.Interfaces;

namespace TravelBlogWebApp.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private TravelBlogDbContext context { get; set; }

        public BaseRepository(TravelBlogDbContext context)
        {
            this.context = context;
        }

        public IQueryable<T> FindAll()
        {
            return this.context.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.context.Set<T>().Where(expression).AsNoTracking();
        }

        public void Create(T entity)
        {
            this.context.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            this.context.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            this.context.Set<T>().Remove(entity);
        }
    }
}
