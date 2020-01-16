using System;

namespace ArrayCRUD
{
    public class IntArray
    {
        private readonly int initialLength = 4;
        private int[] arr;

        public IntArray() => arr = new int[initialLength];

        public int Count { get; protected set; }

        public virtual int this[int index]
        {
            get => arr[index];
            set => arr[index] = value;
        }

        public virtual void Add(int element)
        {
            ResizeArray();
            arr[Count] = element;
            Count++;
        }

        public int IndexOf(int element)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == element)
                {
                    return i;
                }
            }

            return -1;
        }

        public bool Contains(int element)
        {
            return this.IndexOf(element) != -1;
        }

        public virtual void Insert(int index, int element)
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

        public void Remove(int element)
        {
            int position = this.IndexOf(element);
            RemoveAt(position);
        }

        public void RemoveAt(int index)
        {
            ShiftLeft(index);
            Array.Resize(ref arr, arr.Length - 1);
            Count--;
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
