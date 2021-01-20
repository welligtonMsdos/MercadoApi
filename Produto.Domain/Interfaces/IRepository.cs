using System.Collections.Generic;
using System.Threading.Tasks;

namespace Produto.Domain.Interfaces
{
    public interface IRepository<T> where T: class
    {       
        Task<ICollection<T>> GetAll();       
        Task<T> GetById(int id);
        Task Insert(T obj);
        Task Update(T obj);
        Task Delete(int id);
    }
}
