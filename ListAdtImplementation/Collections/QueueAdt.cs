using System;
using System.Threading;

namespace ListAdtImplementation.Collections
{
    public class QueueAdt<Obj>
    {
        private LinkedListAdt<Obj> linkedList;
        public int Count { get => linkedList.Count; }

        public QueueAdt()
        {
            linkedList = new LinkedListAdt<Obj>();
        }

        public void Add(Obj objToAdd)
        {
            linkedList.AddToEnd(objToAdd);
        }

        public Obj Peek()
        {
            if (Count == 0)
                throw new InvalidOperationException();

            return linkedList.Head.Value;
        }

        public Obj GetNext()
        {
            if (Count == 0)
                throw new InvalidOperationException();

            var nextValue = linkedList.Head.Value;
            linkedList.RemoveFromStart();
            return nextValue;
        }
    }
}
