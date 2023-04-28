namespace TravelBlogWebApp.Repositories.Interfaces
{
    public interface IBaseRepository<T>
    {
        public IEnumerable<T> GetAll();

        public T GetById (int id);  

        public void Add (T entity);

        public void Update (T entity);  

        public void Delete (T entity);  
        
    }
}
