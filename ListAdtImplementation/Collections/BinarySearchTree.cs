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

        public void Remove(T value) => Remove(Root, value);

        private void Remove(Node node, T value)
        {
            var currentNode = node;
            Node parent = currentNode.Parent ?? null;

            while (currentNode != null && value.CompareTo(currentNode.Value) != 0)
            {
                parent = currentNode;

                var comp = value.CompareTo(currentNode.Value);
                if (comp < 0)
                    currentNode = currentNode.Left;
                else if (comp > 0)
                    currentNode = currentNode.Right;
            }

            if (currentNode == null) return;

            if (currentNode.IsLeaf())
            {
                if (currentNode.Value.CompareTo(Root.Value) != 0)
                {
                    if (parent.Left == currentNode)
                        parent.Left = null;
                    else
                        parent.Right = null;
                }
                else
                {
                    Root = null;
                }
            }

            else if (currentNode.Left != null && currentNode.Right != null)
            {
                Node successor = FindMin(currentNode.Right);
                currentNode.Value = successor.Value;
                Remove(currentNode.Right, successor.Value);
            }

            else
            {
                var currentNodeChild = currentNode.Left ?? currentNode.Right;
                currentNodeChild.Parent = parent;

                if (currentNode != Root)
                {
                    if (parent.Right == currentNode)
                        parent.Right = currentNodeChild;
                    else
                        parent.Left = currentNodeChild;
                }
                else
                {
                    Root = null;
                }
            }
        }

        public void SetNull(Node t) => t.Right = null;

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
            public Node Left { get; set; }
            public Node Right { get; set; }
            public Node Parent { get; set; }
            public T Value { get; set; }

            public bool IsLeaf() => Left == null && Right == null;
        }
    }
}
