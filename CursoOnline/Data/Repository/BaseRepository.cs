using CursoOnline.Domain.Entities;
using CursoOnline.Domain.Interfaces.Base;
using Data.Context;
using System.Collections.Generic;
using System.Linq;

namespace Data.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : Entity
    {
        protected readonly ApplicationDbContext _Context;

        public BaseRepository(ApplicationDbContext context)
        {
            _Context = context;
        }

        public void Insert(T entity)
        {
            _Context.Set<T>().Add(entity);
        }

        public T FindById(int id)
        {
            var query = _Context.Set<T>().Where(w => w.Id == id);
            return query.Any() ? query.First() : null;
        }

        public List<T> Search()
        {
            var entities = _Context.Set<T>().ToList();
            return entities.Any() ? entities : new List<T>();
        }
    }
}
