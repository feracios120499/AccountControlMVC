using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountControlMVC.Models
{
    interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Create(T Object);
        void Update(T oldObject,T newObject);
        void Delete(T Object);
    }
}
