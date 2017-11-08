using Portal.Domain.Common;
using System;
using System.Collections.Generic;

namespace App.Shared
{
    public interface IRepository<T> where T : AggregateRoot
    {
        T GetById(int id);
        IEnumerable<T> Find(Func<T, bool> term);
        void Create(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}