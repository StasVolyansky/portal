using Portal.Domain.Common;

namespace App.Shared
{
    public interface IWriteRepository<in T> where T : Entity
    {
        void Create(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}