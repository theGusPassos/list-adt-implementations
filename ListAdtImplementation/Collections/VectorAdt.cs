﻿using System;

namespace ListAdtImplementation.Collections
{
    public class VectorAdt<Obj>
    {
        private const int baseCapacity = 16;

        private Obj[] array;

        public int Capacity { get; private set; }
        public int Count { get; private set; }

        public VectorAdt(int capacity = baseCapacity)
        {
            Capacity = capacity;
            array = new Obj[Capacity];
        }

        public VectorAdt(VectorAdt<Obj> vectorToCopy)
        {
            Capacity = vectorToCopy.Capacity;
            Count = vectorToCopy.Count;

            array = new Obj[Capacity];

            for (int i = 0; i < Count; i++)
                array[i] = vectorToCopy[i];
        }

        public void Add(Obj obj)
        {
            if (Count + 1> Capacity)
                DoubleCapacity();

            array[Count] = obj;
            Count++;
        }

        public void Add(params Obj[] objs)
        {
            foreach (var obj in objs)
            {
                Add(obj);
            }
         }

        private void DoubleCapacity()
        {
            Capacity *= 2;

            var newArray = new Obj[Capacity];
            for (int i = 0; i < Count; i++)
                newArray[i] = array[i];

            array = newArray;
        }

        public Obj this[int index]
        {
            get => Get(index);
            set => Set(index, value);
        }

        public Obj Get(int index)
        {
            if (index >= Count)
                throw new IndexOutOfRangeException();

            return array[index];
        }

        public void Set(int index, Obj value)
        {
            if (index >= Capacity)
                throw new IndexOutOfRangeException();

            array[index] = value;
        }
    
        public static bool operator ==(VectorAdt<Obj> left, VectorAdt<Obj> right)
        {
            if (left.Count != right.Count) return false;
            for (int i = 0; i < left.Count; i++)
            {
                if (!left[i].Equals(right[i]))
                    return false;
            }

            return true;
        }

        public static bool operator !=(VectorAdt<Obj> left, VectorAdt<Obj> right)
        {
            return !(left == right);
        }
    }
}
