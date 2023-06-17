using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab12
{
    public class Node<T>
    {
        public T? Data { get; set; }
        public Node<T>? Left { get; set; }
        public Node<T>? Right { get; set; }

        public Node(T? data = default)
        {
            Data = data;
            Left = null;
            Right = null;
        }

        public Node<T> Clone()
        {
            Node<T> node = new(Data);

            if (Left is not null)
                node.Left = (Node<T>)Left.Clone();
            else
                node.Left = null;

            if (Right is not null)
                node.Right = (Node<T>)Right.Clone();
            else
                node.Right = null;
            return node;
        }

        public override string? ToString()
        {
            return Data?.ToString();
        }
    }
}