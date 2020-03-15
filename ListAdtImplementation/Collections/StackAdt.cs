using System;

namespace ListAdtImplementation.Collections
{
    public class StackAdt<Obj>
    {
        private readonly LinkedListAdt<Obj> linkedList;

        public int Count { get => linkedList.Count; }

        public StackAdt()
        {
            linkedList = new LinkedListAdt<Obj>();
        }

        public void Add(Obj toAdd)
        {
            linkedList.AddToEnd(toAdd);
        }

        public bool Empty() => linkedList.Empty();

        public Obj Peek()
        {
            if (Count == 0)
                throw new InvalidOperationException();

            return linkedList.LastNode.Value;
        }

        public Obj Get()
        {
            if (Count == 0)
                throw new InvalidOperationException();

            var lastAdded = linkedList.Tail.Value;
            linkedList.RemoveFromEnd();
            return lastAdded;
        }
    }
}
