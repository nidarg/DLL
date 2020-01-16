namespace ArrayCRUD
{
    public class SortedIntArray : IntArray
    {
        public SortedIntArray() : base()
        {
        }

        public override int this[int index]
        {
            get => base[index];
            set
                {
                if (!VerifyIfSortedAtSetElement(index, value))
                {
                    return;
                }

                base[index] = value;
            }
        }

        public bool VerifyIfSortedAtAdd(int element)
        {
            return element >= base[Count - 1];
        }

        public override void Add(int element)
        {
            base.Insert(FindRightPosition(element), element);
        }

        public override void Insert(int index, int element)
        {
            if (!VerifyIfSortedAtInsertElement(index, element))
            {
                return;
            }

            base.Insert(index, element);
        }

        private bool VerifyIfSortedAtSetElement(int index, int element)
        {
            return GetValue(index - 1, element) <= element && element <= GetValue(index + 1, element);
        }

        private bool VerifyIfSortedAtInsertElement(int index, int element)
        {
            return GetValue(index - 1, element) <= element && element <= GetValue(index, element);
        }

        private int FindRightPosition(int element)
        {
            if (Count == 0)
            {
                return Count;
            }

            for (int i = 0; i < Count; i++)
            {
                if (element <= base[i])
                {
                    return i;
                }
            }

            return Count;
        }

        private int GetValue(int index, int defaultValue) => (index < 0 || index > Count - 1) ? defaultValue : base[index];
    }
}
