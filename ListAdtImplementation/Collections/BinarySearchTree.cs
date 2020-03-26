using System;

namespace ListAdtImplementation.Collections
{
    public class BinarySearchTree<T> where T : IComparable
    {
        public Node Root { get; private set; }

        public void Add(T value)
        {
            if (Root == null)
                Root = new Node { Value = value };

            Node currentNode = Root;
            while (value.CompareTo(currentNode.Value) != 0)
            {
                if (value.CompareTo(currentNode.Value) < 0)
                {
                    if (currentNode.Left == null)
                    {
                        var newNode = new Node { Value = value, Parent = currentNode };
                        currentNode.Left = newNode;
                    }
                        
                    currentNode = currentNode.Left;
                }
                else
                {
                    if (currentNode.Right == null)
                    {
                        var newNode = new Node { Value = value, Parent = currentNode };
                        currentNode.Right = newNode;
                    }
                        
                    currentNode = currentNode.Right;
                }
            }
        }

        public bool Search(T value)
        {
            var currentNode = Root;
            while(currentNode != null)
            {
                int diff = value.CompareTo(currentNode.Value);
                if (diff == 0) return true;
                if (diff < 0) currentNode = currentNode.Left;
                else currentNode = currentNode.Right;
            }

            return false;
        }

        public class Node
        {
            public Node Left { get; set; }
            public Node Right { get; set; }
            public Node Parent { get; set; }
            public T Value { get; set; }

            public bool IsLeaf() => Left == null && Right == null;
        }
    }
}
