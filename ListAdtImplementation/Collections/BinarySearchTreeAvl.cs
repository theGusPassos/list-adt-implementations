using System;

namespace ListAdtImplementation.Collections
{
    public class BinarySearchTreeAvl<T> where T : IComparable
    {
        private const int ALLOWED_IMBALANCE = 1;

        public Node Root { get; private set; }

        public void Add(T value) => Root = Add(value, Root);

        private Node Add(T value, Node node)
        {
            if (node == null)
                return new Node { Value = value, Height = 1 };

            int diff = value.CompareTo(node.Value);

            if (diff < 0)
                node.Left = Add(value, node.Left);
            else if (diff > 0)
                node.Right = Add(value, node.Right);

            return node;
        }

        public void Remove(T value) => Root = Remove(value, Root);

        private Node Remove(T value, Node node)
        {
            if (node == null) return null;

            int diff = value.CompareTo(node.Value);
            if (diff == 0)
            {
                if (node.IsLeaf()) return null;
                else if (node.HasBothChildren())
                {
                    var successor = FindMin(node.Right);
                    node.Value = successor.Value;
                    node.Right = Remove(successor.Value, node.Right);
                }
                else if (node.HasChildren()) return node.Left ?? node.Right;
            }

            if (diff < 0)
                node.Left = Remove(value, node.Left);
            else if (diff > 0)
                node.Right = Remove(value, node.Right);

            return node;
        }

        private void Balance(Node node)
        {
            node.Height = node.GetMaxHeightInChildren() + 1;
        }

        public bool Contains(T value)
        {
            var currentNode = Root;
            while (currentNode != null)
            {
                int diff = value.CompareTo(currentNode.Value);
                if (diff == 0) return true;
                if (diff < 0) currentNode = currentNode.Left;
                else currentNode = currentNode.Right;
            }

            return false;
        }

        private Node FindMin(Node node)
        {
            if (node == null) return null;
            if (node.Left == null) return node;

            var currentNode = node.Left;
            while (currentNode.Left != null)
                currentNode = currentNode.Left;

            return currentNode;
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

            public int GetMaxHeightInChildren()
            {
                var rightHeight = Right != null ? Right.Height : -1;
                var leftHeight = Left != null ? Left.Height : -1;
                return Math.Max(rightHeight, leftHeight);
            }
        }
    }
}
