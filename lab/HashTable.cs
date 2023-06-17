using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab12
{
    public class HashTable<T> : IEnumerable<T>
    {
        private Node2<T>[] array = null;
        public int Capacity => array.Length; 
        public int Count { get; private set; } 

        public HashTable(int capacity)
        {
            if (capacity < 0) capacity = 0;
            array = new Node2<T>[capacity];
        }

        private int FindIndex(T key)
        {
            int index = GetHash(key);
            int compare;
            Node2<T> currentElem = array[index]; // temporary var

            if ((currentElem != null && !currentElem.isDeleted) || currentElem.Next != null)
            {
                compare = string.Compare(currentElem.Key.ToString(), key.ToString());

                if (compare == 0) return index;

                else
                {
                    while (currentElem.Next != null)
                    {
                        currentElem = currentElem.Next;
                        compare = string.Compare(currentElem.Key.ToString(), key.ToString());

                        if (compare == 0 && !currentElem.isDeleted) return index;
                    }
                    return -1;
                }
            }
            return -1;
        }

        private void Resize()
        {
            Node2<T>[] tempArray = new Node2<T>[array.Length * 2];

            for (int i = 0; i < array.Length; i++) 
            {
                Node2<T> temp = null;
                int newIndex;

                while (array[i] != null && array[i].Next != null)
                {
                    temp = temp.Next;
                    newIndex = Math.Abs(temp.Key.GetHashCode() % tempArray.Length);

                    if (tempArray[newIndex] == null) tempArray[newIndex] = temp; // if place is free

                    else // if place is not free
                    {
                        Node2<T> tempElemOfNewArray = tempArray[newIndex];

                        while (tempElemOfNewArray.Next != null) tempElemOfNewArray = tempElemOfNewArray.Next;

                        tempElemOfNewArray.Next = temp;
                    }
                }
            }
            array = tempArray;
        }

        private int GetHash(T key) {
            return key.GetHashCode() % array.Length;
        }

        public void Add(T item)
        {
            Node2<T> node = new Node2<T>(item, item);

            if (Count * 0.5f > array.Length) Resize();

            Count++;
            int index = GetHash(item);

            if (array[index] == null) array[index] = node; // if place is free

            else // if place is not free
            {
                Node2<T> current = array[index];

                while (current.Next != null) current = current.Next;
                current.Next = node;
            }
        }

        public bool Contains(T key)
        {
            int index = FindIndex(key);

            if (index < 0) return false;
            return true;
        }

        public bool Remove(T key)
        {
            int index = FindIndex(key);
            if (index < 0) return false; 

            Node2<T> current = array[index];

            while (current.Key.ToString() != key.ToString()) current = current.Next; // if keys are not equal
            current.isDeleted = true; // and if equal we need to delete (isDelete = true and it'll be deleted in GetEnumerator())
            Count--;

            return true; 
        }

        public IEnumerator<T> GetEnumerator() // for using foreach in Program.cs
        {
            if (array.Length == 0 || array == null || Count == 0) throw new Exception("Хеш-таблица пуста");

            for (int i = 0; i < array.Length; i++) 
            {
                if (array[i] != null && !array[i].isDeleted) 
                {
                    yield return array[i].Value; 

                    Node2<T> temp = array[i];

                    while (temp.Next != null)
                    {
                        temp = temp.Next;
                        if (!temp.isDeleted) yield return temp.Value;
                    }
                }

                if (array[i] != null && array[i].isDeleted && array[i].Next != null) // if isDeleted = true but we have chain of elements
                {
                    Node2<T> temp = array[i].Next; 

                    if (!temp.isDeleted) yield return temp.Value; 

                    while (temp.Next != null) 
                    {
                        temp = temp.Next; 
                        if (!temp.isDeleted) yield return temp.Value; 
                    }
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => (IEnumerator<T>)GetEnumerator();
    }
}