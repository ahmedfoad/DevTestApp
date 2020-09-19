using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevTest_Repository.Repos
{
    public interface IRepository<T> where T: class
    {
        Task<IEnumerable<T>> GetAll();
        T GetbyId(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
