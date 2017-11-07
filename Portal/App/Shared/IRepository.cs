using Portal.Domain.Common;

namespace App.Shared
{
    public interface IRepository<T> where T : Entity
    {
        T GetById(int id);
        void Create(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}