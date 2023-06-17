using MyClassLibrary;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Console;

namespace Lab12
{
    public class BinaryTree<T>
    {
        public Node<T>? Root { get; set; }
        public List<int> Ages = new List<int>();
        public Node<int>? IntRoot;
        public int Count { get; private set; }

        // for ideal balanced tree
        public BinaryTree(int count)
        {
            Count = count;
            Root = CreateIdealBalancedTree(count, Root);
        }

        // for search tree
        public BinaryTree(int count, List<int> Values)
        {
            Count = count;
            IntRoot = CreateSearchTree(Values);
        }

        // for ideal balanced tree
        private Node<T> CreateIdealBalancedTree(int count, Node<T>? root)
        {
            if (count == 0) return root;
            
            int left = count / 2;
            int right = count - left - 1;

            Person person = new Person();
            person.RandomInit();

            Ages.Add(person.Age);

            root = new Node<T>((T)(object)person);
            root.Left = CreateIdealBalancedTree(left, root.Left); 
            root.Right = CreateIdealBalancedTree(right, root.Right);

            return root;
        }

        // for search tree
        public Node<int> CreateSearchTree(List<int> Ages)
        {
            Node<int> CreateSearchTreeRecursion(List<int> values, int start, int end)
            {
                if (start > end) return null;
                int mid = (start + end) / 2;
                Node<int> root = new Node<int>(values[mid]);
                root.Right = CreateSearchTreeRecursion(values, start, mid - 1);
                root.Left = CreateSearchTreeRecursion(values, mid + 1, end);
                return root;
            }

            Ages.Sort();
            return CreateSearchTreeRecursion(Ages, 0, Ages.Count - 1);
        }

        // for ideal balanced tree
        public void ShowIdealBalancedTree() 
        {
            void ShowRecursion(Node<T> node, int l)
            {
                if (node != null)
                {
                    ShowRecursion(node.Left, l + 1);
                    for (int i = 0; i < l; i++) Write("--- ");

                    Person person = (Person)(object)node.Data;
                    if (person is not null) WriteLine(person.Name);
                    ShowRecursion(node.Right, l + 1);
                }
            }

            if (Root != null) ShowRecursion(Root, 1);
            else WriteLine("Дерево пустое");
        }

        // for search tree
        public void ShowSearchTree() 
        {
            void ShowRecursion(Node<int> node, int l)
            {
                if (node != null)
                {
                    ShowRecursion(node.Left, l + 1);
                    for (int i = 0; i < l; i++) Write("--- ");

                    var person = node.Data;
                    WriteLine(person);
                    ShowRecursion(node.Right, l + 1);
                }
            }

            if (IntRoot != null) ShowRecursion(IntRoot, 1);
            else WriteLine("Дерево не содержит элементов");
        }

        public string MinAge()
        {
            int age = Ages.Min();
            string name = "";
            Search(Root, age, ref name);
            return ($"Минимальный возраст {age} у человека с именем {name}");
        }

        public void Search(Node<T> root, int age, ref string name)
        {
            if (root != null)
            {
                if (root.Data is Person person && person.Age == age)
                {
                    name = person.Name;
                    return;
                }
                Search(root.Left, age, ref name);
                Search(root.Right, age, ref name);
            }
        }

        public void Erase()
        {
            Root = null;
            GC.Collect();
        }
    }
}