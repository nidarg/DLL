using System;
using System.Collections;

namespace ArrayCRUD
{
    public class ObjectEnumerator : IEnumerator
    {
        private readonly object[] array;
        private int currentIndex = -1;

        public ObjectEnumerator(object[] arr)
        {
            array = arr;
        }

        public object Current
        {
            get
            {
                try
                {
                    return array[currentIndex];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }

        public bool MoveNext()
        {
            currentIndex++;

            return currentIndex < array.Length;
        }

        public void Reset()
        {
            currentIndex = -1;
        }
    }
}
