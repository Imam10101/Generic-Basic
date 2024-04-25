using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Generic
{
    //Solid
    public interface IBase<T> where T:class
    {
        void Add(T item);
        void Remove(T item);
        List<T> GetAll();
    }
}
