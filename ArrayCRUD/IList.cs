using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ArrayCRUD
{
    public class IListCollection<T> : IList<T>
    {
        private const string NotSuportedExceptionMessage = "The collection is read only";
        private const string ArgumentOutOfRangeExceptionMessage = "Wrong index";
        private readonly int initialLength = 4;
        private T[] arr;
        private bool readOnly;

        public IListCollection() => arr = new T[initialLength];

        public int Count { get; protected set; }

        public bool IsReadOnly
        {
            get
            {
                return readOnly;
            }
        }

        public T this[int index]
        {
            get
            {
                if (!ValidIndex(index))
                {
                    throw new ArgumentOutOfRangeException("index", ArgumentOutOfRangeExceptionMessage);
                }

                return arr[index];
            }

            set
            {
                if (!ValidIndex(index))
                {
                    throw new ArgumentOutOfRangeException("index", ArgumentOutOfRangeExceptionMessage);
                }

                arr[index] = value;
            }
        }

        public void ReadOnly()
        {
            readOnly = true;
        }

        public bool ValidIndex(int index)
        {
            return index >= 0 && index <= arr.Length - 1;
        }

        public void Add(T item)
        {
            if (IsReadOnly)
            {
                throw new NotSupportedException(NotSuportedExceptionMessage);
            }

            ResizeArray();
            arr[Count] = item;
            Count++;
        }

        public void Clear()
        {
            if (IsReadOnly)
            {
                throw new NotSupportedException(NotSuportedExceptionMessage);
            }

            Count = 0;
        }

        public bool Contains(T item)
        {
            return this.IndexOf(item) != -1;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array), "array can 't be null");
            }

            if (arrayIndex < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(arrayIndex), "start index must be positive");
            }

            if (array.Length - arrayIndex < Count)
            {
                throw new ArgumentException("Not enough space to copy all elements");
            }

            for (int i = 0; i < Count; i++)
            {
                arr[i + arrayIndex] = this[i];
            }
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
            if (!ValidIndex(index))
            {
                throw new ArgumentOutOfRangeException(nameof(index), message: ArgumentOutOfRangeExceptionMessage);
            }

            if (IsReadOnly)
            {
                throw new NotSupportedException(NotSuportedExceptionMessage);
            }

            ResizeArray();
            ShiftRight(index);
            arr[index] = item;
            Count++;
        }

        public void RemoveAt(int index)
        {
            if (!ValidIndex(index))
            {
                throw new ArgumentOutOfRangeException(nameof(index), message: ArgumentOutOfRangeExceptionMessage);
            }

            if (IsReadOnly)
            {
                throw new NotSupportedException(NotSuportedExceptionMessage);
            }

            ShiftLeft(index);
            Array.Resize(ref arr, arr.Length - 1);
            Count--;
        }

        public bool Remove(T item)
        {
            if (IsReadOnly)
            {
                throw new NotSupportedException(NotSuportedExceptionMessage);
            }

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
