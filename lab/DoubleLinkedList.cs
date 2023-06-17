using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lab12
{
    public class DoublyLinkedList<T> : IEnumerable<T>
    {
        public Item<T> Head { get; set; }
        public Item<T> Tail { get; set; }
        public int Count { get; set; }
        public DoublyLinkedList() { }
        public DoublyLinkedList(T data)
        {
            var item = new Item<T>(data);
            Head = item;
            Tail = item;
            Count = 1;
        }
        public void Add(T data)
        {
            var item = new Item<T>(data);
            if (Count == 0)
            {
                Head = item;
                Tail = item;
                Count = 1;
                return;
            }
            Tail.Next = item;
            item.Previous = Tail;
            Tail = item;
            Count++;
        }
        //public void Delete(T data)
        //{
        //    var current = Head;
        //    while (current.Next != null)
        //    {
        //        if (current.Data.Equals(data))
        //        {
        //            current.Previous.Next = current.Next;
        //            current.Next.Previous = current.Previous;
        //            Count--;
        //        }
        //        current = current.Next;
        //    }
        //}
        public void Insert(T data, int position)
        {
            var item = new Item<T>(data);
            if (Count == 0)
            {
                Head = item;
                Tail = item;
                Count = 1;
                return;
            }
            if (position == 0)
            {
                item.Next = Head;
                Head.Previous = item;
                Head = item;
                Count++;
            }
            else
            {
                Item<T> current = Head;
                for (int i = 0; i < position - 1; i++)
                    current = current.Next;
                item.Next = current.Next;
                current.Next.Previous = item;
                current.Next = item;
                item.Previous = current;
                Count++;
            }
        }
        public IEnumerator GetEnumerator()
        {
            var current = Head;
            while (current != null)
            {
                yield return current;
                current = current.Next;
            }
        }
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return (IEnumerator<T>)GetEnumerator();
        }
        public void Clear()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }
    }
}
