using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Api.Datos.Interface
{
    public interface IRepositorioGenerico<T> where T: class
    {
        Task<List<T>> Get();
        Task<T> Find(string id);
        Task<T> Add(T t);
        Task<bool> Update(T t);
        Task<bool> Delete(string id);
    }
}
