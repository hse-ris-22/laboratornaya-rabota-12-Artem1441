using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab12
{
    public class Item<T>
    {
        public T Data { get; set; }
        public Item<T> Next { get; set; }
        public Item<T> Previous { get; set; }
        public Item(T data)
        {
            Data = data;
        }
        public override string ToString() => Data + " ";
    }
}
