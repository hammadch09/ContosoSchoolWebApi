using ContosoSchool.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ContosoSchool.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _context;
        private DbSet<T> entities;
        public Repository(ApplicationDbContext context)
        {
            _context = context;
            entities = _context.Set<T>();
        }
        public T Get(int id)
        {
            var entity = entities.SingleOrDefault(x => x.Id == id);
            if (entity == null)
            {
                throw new ArgumentNullException("No Record found!");
            }
            return entity;
        }

        public IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable();
        }

        public void Create(T entity)
        {
            if (entity == null)
                throw new NotImplementedException();

            entities.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            if (entity == null)
                throw new NotImplementedException();

            entities.Remove(entity);
            _context.SaveChanges();
        }

        public void Remove(T entity)
        {
            if (entity == null)
                throw new NotImplementedException();

            entities.Remove(entity);
        }

        public void Update(T entity)
        {
            if (entity == null)
                throw new NotImplementedException();

            entities.Update(entity);
            _context.SaveChanges();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
