using System.Linq.Expressions;
using TravelBlogWebApp.Models;
using TravelBlogWebApp.Repositories;
using TravelBlogWebApp.ServicesFolder.Interfaces;

namespace TravelBlogWebApp.ServicesFolder
{
    public class SectionService:ISectionService
    {

        private readonly RepositoryWrapper repositoryWrapper;

        public SectionService(RepositoryWrapper repository)
        {
            this.repositoryWrapper = repository;
        }

        public IQueryable<Section> FindAll()
        {
            return repositoryWrapper.SectionRepository.FindAll();
        }


        public void Create(Section entity)
        {
            repositoryWrapper.SectionRepository.Create(entity);
            repositoryWrapper.Save();
        }


        public void Update(Section entity)
        {
            repositoryWrapper.SectionRepository.Update(entity);
            repositoryWrapper.Save();
        }


        public void Delete(Section entity)
        {
            repositoryWrapper.SectionRepository.Delete(entity);
            repositoryWrapper.Save();
        }

        public IQueryable<Section> FindByCondition(Expression<Func<Section, bool>> expression)
        {
            return repositoryWrapper.SectionRepository.FindByCondition(expression);

        }
    }

}

