using DeadEntity.IRepository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityOfWorck.Repositorys
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbContext _dbContext;
        public DbSet<T> DbSet { get; private set; }

        public Repository(DbContext context)
        {
            _dbContext = context;
            DbSet = _dbContext.Set<T>();
        }
        public IQueryable<T> GetAll()
        {
            return DbSet;
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
        }

        public T GetById(int id)
        {
            return DbSet.Find(id);
        }

        public bool RemoveById(int id)
        {
            try
            {
                DbSet.Remove(GetById(id));
            }
            catch
            {
                return false;
            }
            return true;
        }

        public void Add(T entity)
        {
            DbSet.Add(entity);
            Commit();
        }
    }
}
