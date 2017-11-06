using Portal.Domain.Common;
using System.Collections.Generic;

namespace App.Shared
{
    public interface IReadRepository<out T> where T : Entity
    {
        IEnumerable<T> GetAll();
        T Get(int id);
    }
}