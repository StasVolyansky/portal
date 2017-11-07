using System.Collections.Generic;

namespace App.Shared
{
    public interface IReadRepository<out T> where T : ViewModel
    {
        IEnumerable<T> GetAll();
        T Get(int id);
    }

    public class ViewModel
    {

    }
}