using System;
using System.Collections;

namespace ArrayCRUD
{
    public class ObjectEnumerator : IEnumerator
    {
        private readonly ObjectArrayCollection arr;
        private int currentIndex = -1;

        public ObjectEnumerator(ObjectArrayCollection array)
        {
            arr = array;
        }

        object IEnumerator.Current => currentIndex >= 0 && currentIndex <= arr.Count ? arr[currentIndex] : null;

        public bool MoveNext()
        {
            currentIndex++;

            return currentIndex < arr.Count;
        }

        public void Reset()
        {
            currentIndex = -1;
        }
    }
}
