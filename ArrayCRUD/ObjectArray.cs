using System;
using System.Collections;

namespace ArrayCRUD
{
    public class ObjectArrayCollection : IEnumerable
    {
        private readonly int initialLength = 4;
        private object[] arr;

        public ObjectArrayCollection() => arr = new object[initialLength];

        public int Count { get; protected set; }

        public object this[int index]
        {
            get => arr[index];
            set => arr[index] = value;
        }

        public IEnumerator GetEnumerator()
        {
            return new ObjectEnumerator(this);
        }

        public void Add(object element)
        {
            ResizeArray();
            arr[Count] = element;
            Count++;
        }

        public int IndexOf(object element)
        {
            for (int i = 0; i < Count; i++)
            {
                if (arr[i].Equals(element))
                {
                    return i;
                }
            }

            return -1;
        }

        public bool Contains(object element)
        {
            return this.IndexOf(element) != -1;
        }

        public void Insert(int index, object element)
        {
            ResizeArray();
            ShiftRight(index);
            arr[index] = element;
            Count++;
        }

        public void Clear()
        {
            Count = 0;
        }

        public void RemoveAt(int index)
        {
            ShiftLeft(index);
            Array.Resize(ref arr, arr.Length - 1);
            Count--;
        }

        public void Remove(object element)
        {
            RemoveAt(IndexOf(element));
        }

        private void ResizeArray()
        {
            const int doubleSize = 2;
            if (Count != arr.Length)
            {
                return;
            }

            Array.Resize(ref arr, Count * doubleSize);
        }

        private void ShiftLeft(int index)
        {
            for (int i = index; i < arr.Length - 1; i++)
            {
                arr[i] = arr[i + 1];
            }
        }

        private void ShiftRight(int index)
        {
            for (int i = arr.Length - 1; i > index; i--)
            {
                arr[i] = arr[i - 1];
            }
        }
    }
}
