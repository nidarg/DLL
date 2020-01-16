using System;
using System.Collections;
using System.Collections.Generic;

namespace ArrayCRUD
{
        public class ListCollection<T> : IEnumerable<T>
        {
            private readonly int initialLength = 4;
            private T[] arr;

            public ListCollection() => arr = new T[initialLength];

            public int Count { get; protected set; }

            public virtual T this[int index]
            {
                get => arr[index];
                set => arr[index] = value;
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return ((IEnumerable<T>)arr).GetEnumerator();
            }

            public IEnumerator<T> GetEnumerator()
            {
                foreach (T t in arr)
                {
                    yield return t;
                }
            }

            public void PrintList()
            {
                foreach (T item in arr)
                {
                    Console.WriteLine(item);
                }
            }

            public virtual void Add(T element)
                {
                    ResizeArray();
                    arr[Count] = element;
                    Count++;
                }

            public int IndexOf(T element)
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

            public bool Contains(T element)
            {
                return this.IndexOf(element) != -1;
            }

            public virtual void Insert(int index, T element)
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

            public void Remove(T element)
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
