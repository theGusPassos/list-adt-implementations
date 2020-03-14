using System;
using System.Collections.Generic;

namespace ListAdtImplementation.Collections
{
    public class LinkedListAdt<Obj>
    {
        public LinkedListNode Head { get; private set; }
        public LinkedListNode Tail { get; private set; }
        public int Count { get; private set; }

        public void AddToStart(Obj obj)
        {
            if (Head != null)
            {
                var newNode = new LinkedListNode(obj, next: Head);
                Head.Previous = newNode;
                Head = newNode;
            }
            else
            {
                Head = new LinkedListNode(obj);
            }

            Count++;
        }

        public void AddToEnd(Obj obj)
        {
            if (Tail == null && Head == null)
            {
                AddToStart(obj);
                return;
            }
            else if (Tail == null)
            {
                Tail = new LinkedListNode(obj, previous: Head);
                Head.Next = Tail;
            }
            else
            {
                var newNode = new LinkedListNode(obj, previous: Tail);
                Tail.Next = newNode;
                Tail = newNode;
            }

            Count++;
        }

        public bool Empty() => Count == 0; 

        public void RemoveFromStart()
        {
            if (Empty())
                throw new InvalidOperationException();

            if (Head == null) return;
            if (Head.Next == null)
            {
                Head = null;
                Count--;
                return;
            }

            if (Head.Next == Tail)
            {
                Tail = null;
            }

            var nextHead = Head.Next;
            nextHead.Previous = null;
            Head = nextHead;

            Count--;
        }

        public void RemoveFromEnd()
        {
        }

        public class LinkedListNode
        {
            public LinkedListNode Next { get; set; }
            public LinkedListNode Previous { get; set; }
            public Obj Value { get; set; }

            public LinkedListNode(Obj value, LinkedListNode next = null, LinkedListNode previous = null)
            {
                Value = value;
                Next = next;
                Previous = previous;
            }
        }
    }
}
