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

            if (Root.Value.CompareTo(value) == 0)
                return;

            if (value.CompareTo(Root.Value) > 0)
            {
                var newNode = new Node { Value = value, Parent = Root };
                Root.Right = newNode;
            }
            else
            {
                var newNode = new Node { Value = value, Parent = Root };
                Root.Left = newNode;
            }
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
