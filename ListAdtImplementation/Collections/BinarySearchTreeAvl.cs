﻿using System;

namespace ListAdtImplementation.Collections
{
    public class BinarySearchTreeAvl<T> where T : IComparable
    {
        private const int ALLOWED_IMBALANCE = 1;

        public Node Root { get; private set; }

        public void Add(params T[] values)
        {
            foreach (var t in values)
                Add(t);
        }

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

            node = Balance(node);
            node.Height = node.GetMaxHeightInChildren() + 1;

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

        private Node Balance(Node node)
        {
            if (Height(node.Right) - Height(node.Left) > ALLOWED_IMBALANCE)
            {
                if (Height(node.Right.Right) >= Height(node.Right.Left))
                {
                    return RotateWithRightChild(node);
                }
                else return DoubleRotateWithRightChild(node);
            }
            else if (Height(node.Left) - Height(node.Right) > ALLOWED_IMBALANCE)
            {
                if (Height(node.Left.Left) >= Height(node.Left.Right))
                {
                    return RotateWithLeftChild(node);
                }
                else return DoubleRotateWithLeftChild(node);
            }

            return node;
        }

        public int Height(Node node)
            => node != null ? node.Height : 0;

        private Node RotateWithRightChild(Node node)
        {
            var newTop = node.Right;
            node.Right = newTop.Left;
            newTop.Left = node;

            return newTop;
        }

        private Node RotateWithLeftChild(Node node)
        {
            var newTop = node.Left;
            node.Left = newTop.Right;
            newTop.Right = node;

            return newTop;
        }

        private Node DoubleRotateWithRightChild(Node node)
        {
            node.Right = RotateWithLeftChild(node.Right);
            return RotateWithRightChild(node);
        }

        private Node DoubleRotateWithLeftChild(Node node)
        {
            node.Left = RotateWithRightChild(node.Left);
            return RotateWithLeftChild(node);
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
