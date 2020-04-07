using System;

namespace ListAdtImplementation.Collections
{
    public class BinarySearchTreeAvl<T> where T : IComparable
    {
        public Node Root { get; private set; }

        public void Add(T value) => Root = Add(value, Root);

        public Node Add(T value, Node node)
        {
            if (node == null)
                return new Node { Value = value };

            int diff = value.CompareTo(node.Value);

            if (diff < 0)
                node.Left = Add(value, node.Left);
            else if (diff > 0)
                node.Right = Add(value, node.Right);

            return node;
        }

        public class Node
        {
            public T Value { get; set; }
            public Node Right { get; set; }
            public Node Left { get; set; }
            public int Height { get; set; }
            
            public bool IsLeaf() => Left == null && Right == null;
            public bool HasBothChildren() => Left != null && Right != null;
            public bool HasChildren() => Left != null || Right != null;
        }
    }
}
