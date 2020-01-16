using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ArrayCRUD
{
    public class IListCollection<T> : IList<T>
    {
        private readonly int initialLength = 4;
        private T[] arr;

        public IListCollection() => arr = new T[initialLength];

        public int Count { get; protected set; }

        public bool IsReadOnly => throw new NotImplementedException();

        public T this[int index]
        {
            get => arr[index];
            set => arr[index] = value;
        }

        public void Add(T item)
        {
            ResizeArray();
            arr[Count] = item;
            Count++;
        }

        public void Clear()
        {
            Count = 0;
        }

        public bool Contains(T item)
        {
            return this.IndexOf(item) != -1;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (T t in arr)
            {
                yield return t;
            }
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (arr[i].Equals(item))
                {
                    return i;
                }
            }

            return -1;
        }

        public void Insert(int index, T item)
        {
            ResizeArray();
            ShiftRight(index);
            arr[index] = item;
            Count++;
        }

        public void RemoveAt(int index)
        {
            ShiftLeft(index);
            Array.Resize(ref arr, arr.Length - 1);
            Count--;
        }

        public bool Remove(T item)
        {
            if (IndexOf(item) == -1)
            {
                return false;
            }

            RemoveAt(IndexOf(item));
            return true;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)arr).GetEnumerator();
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
