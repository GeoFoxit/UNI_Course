using back_end.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace back_end.Services
{
    public interface IService<T>
    {
        List<T> GetAll();
        T GetById(Int32 id);
        List<T> GetListById(Int32 id);
        T GetUser(string username, string password);
        T Add(T t);
        T Delete(Int32 id);
        T Update(Int32 id);
    }
}
