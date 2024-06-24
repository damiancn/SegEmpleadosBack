

namespace DataAcccess.Interface
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICatalogDao<T> where T : class
    {
        Task<List<T>> GetAll();
        Task<T> GetById(Guid id);
        Task<T> Post(T model);
        Task<T> Put(Guid id, T model);
    }
}
