namespace ListAdtImplementation.Collections
{
    public class BinarySearchTree<T>
    {
        public Node Root { get; private set; }

        public void Add(T node)
        {
        }

        public class Node
        {
            public Node Left { get; private set; }
            public Node Right { get; private set; }
            public T Value { get; private set; }

            public bool IsLeaf() => Left == null && Right == null;
        }
    }
}
