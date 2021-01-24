using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotNet_Lista11.DataContext
{
    public interface ICRUDContext<T>
    {
        List<T> GetViewModels();
        T Read(int id);
        bool Create(T item);
        bool Update(T item);
        bool Delete(int id);
    }
}
