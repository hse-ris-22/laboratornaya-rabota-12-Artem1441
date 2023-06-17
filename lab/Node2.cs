using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab12
{
    public class Node2<T>
    {
        public T Key { get; set; }
        public T Value { get; set; }
        public Node2<T> Next { get; set; }

        public bool isDeleted;

        public Node2(T key, T value, Node2<T> next = null, bool isDeleted = false)
        {
            Key = key;
            Value = value;
            Next = next;
        }
    }
}