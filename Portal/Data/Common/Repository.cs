using App.Shared;
using Portal.Data.System;
using Portal.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Portal.Data.Common
{
    public class Repository<T> : IRepository<T> where T : AggregateRoot
    {
        private readonly SystemContext context;

        public Repository(SystemContext context)
        {
            this.context = context;
        }

        public void Create(T entity)
        {
            context.Set<T>().Add(entity);
            context.SaveChanges();
        }

        public void Update(T entity)
        {
            context.Set<T>().Update(entity);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            context.Set<T>().Remove(GetById(id));
            context.SaveChanges();
        }

        public IEnumerable<T> Find(Func<T, bool> term) =>
            Enumerable.Where(context.Set<T>(), term);

        public T GetById(int id) =>
            Queryable.Single(context.Set<T>(), e => e.Id == id);
    }
}