using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Generic
{
    public class Base<T> : IBase<T> where T:class
    {
        List<T> data = new List<T>();
        public void Add(T item)
        {
            data.Add(item);
        }
        public List<T> GetAll()
        {
            return data;
        }
        public void Remove(T item)
        {
            data.Remove(item);
        }
    }
}
