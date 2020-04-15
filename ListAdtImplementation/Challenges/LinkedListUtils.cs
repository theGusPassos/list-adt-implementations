using ListAdtImplementation.Collections;

namespace ListAdtImplementation.Challenges
{
    public static class LinkedListUtils
    {
        public static LinkedListAdt<T> Reverse<T>(this LinkedListAdt<T> linkedList)
        {
            var current = linkedList.Head;

            while (current != null)
            {
                var temp = current.Next;

                current.Next = current.Previous;
                current.Previous = temp;

                if (current == null) linkedList.Head = current;
                current = temp;
            }

            return null;
        }
    }
}
