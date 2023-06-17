using MyClassLibrary;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Lab12
{
    public class SearchTree<T> : IEnumerable<T>, ICollection<T> where T : IComparable<T>, ICloneable
    {
        private Node<T>? root;
        public bool IsReadOnly => false;
        public Node<T>? Root
        {
            get { return root; }
            private set { root = value; }
        }
        public int Count { get; private set; }
        public SearchTree() => root = null;

        public SearchTree(SearchTree<T> tree)
        {
            root = tree.root.Clone();
        }

        public T this[int i]
        {
            get
            {
                int currentIndex = 0;
                foreach (T value in this)
                {
                    if (currentIndex == i)
                        return value;
                    currentIndex++;
                }

                throw new IndexOutOfRangeException();
            }
        }

        public void CopyTo(T[] array, int arrayIndex) => InOrderTraversal(Root, array, ref arrayIndex); // Binary Tree to Array

        private void InOrderTraversal(Node<T> node, T[] array, ref int index)
        {
            if (node != null)
            {
                InOrderTraversal(node.Left, array, ref index);
                array[index++] = node.Data;
                InOrderTraversal(node.Right, array, ref index);
            }
        }

        public virtual void Add(T value)
        {
            if (Root is null) // if the tree is empty, create a new node and make it the root
            {
                root = new Node<T>(value);
                Count++;
                return;
            }
            Node<T> current = Root; // find the appropriate position to insert the new node
            Node<T> parent = current;

            bool isLeft = false;
            while (current is not null)
            {
                parent = current;
                if (value.CompareTo(current.Data) > 0) // go left
                {
                    current = current.Left;
                    isLeft = true;
                }
                else // go right
                {
                    current = current.Right;
                    isLeft = false;
                }
            }
            Node<T> newNode = new(value);
            if (isLeft)
                parent.Left = newNode;
            else
                parent.Right = newNode;
            Count++;
        }

        public virtual void ShowByLevels()
        {
            if (root != null) ShowByLevelsHelper(root, 4);
            else WriteLine("Дерево не содержит элементов");
        }

        private void ShowByLevelsHelper(Node<T> node, int l)
        {
            if (node != null)
            {
                ShowByLevelsHelper(node.Left, l + 4);
                for (int i = 0; i < l; i++) Write("  ");

                Enginer person = (Enginer)(object)node.Data;
                if (person is not null) WriteLine(person.Salary);
                ShowByLevelsHelper(node.Right, l + 4);
            }
        }
        public virtual bool Remove(T value) => Remove(root, value);

        private bool Remove(Node<T> node, T value)
        {
            int compare = value.CompareTo(node.Data);
            if (compare == 0)
            {
                List<T> list = new List<T>();
                foreach (var item in this)
                {
                    if (!item.Equals(node.Data))
                        list.Add(item);
                    list.Sort();
                }
                Count--;
                root = Rebalance(list, 0, list.Count - 1);
                return true;
            }
            if (compare > 0)
                return Remove(node.Left, value);
            return Remove(node.Right, value);
        }

        private static Node<T> Rebalance(List<T> values, int start, int end)
        {
            if (start > end)
                return null;

            int mid = (start + end) / 2;
            Node<T> node = new Node<T>(values[mid]);
            node.Right = Rebalance(values, start, mid - 1);
            node.Left = Rebalance(values, mid + 1, end);

            return node;
        }

        public virtual int IntContains(T value) => Contains(root, value);

        private int Contains(Node<T> node, T value)
        {
            if (node == null)
                return -1;
            int compare = value.CompareTo(node.Data);
            if (compare == 0)
            {
                value = node.Data;
                int currentIndex = 0;
                foreach (var item in this)
                {
                    if (item.Equals(value))
                        return currentIndex;
                    currentIndex++;
                }
            }
            if (compare > 0) return Contains(node.Left, value);
            return Contains(node.Right, value);
        }

        public virtual bool Contains(T value)
        {
            if (IntContains(value) < 0) return false;
            else return true;
        }

        public T ShallowCopy() => (T)this.MemberwiseClone();

        public SearchTree<T> Clone()
        {
            SearchTree<T> tree = new SearchTree<T>();

            tree.root = Root.Clone();

            return tree;
        }

        public void Clear() => root = null;

        public IEnumerator<T> GetEnumerator()
        {
            if (root != null)
            {
                Stack<Node<T>> stack = new Stack<Node<T>>();
                Node<T> current = root;
                bool goRightNext = true;
                stack.Push(current);

                while (stack.Count > 0)
                {
                    if (goRightNext)
                    {
                        while (current.Right != null)
                        {
                            stack.Push(current);
                            current = current.Right;
                        }
                    }

                    yield return current.Data;

                    if (current.Left != null)
                    {
                        current = current.Left;
                        goRightNext = true;
                    }
                    else
                    {
                        current = stack.Pop();
                        goRightNext = false;
                    }
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
