using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ArrayCRUD
{
    public class MySortedListCollection<T> : ListCollection<T>
        where T : IComparable<T>
    {
        public MySortedListCollection() : base()
        {
        }

        public override T this[int index]
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

        public int VerifyIfSortedAtAdd(T element)
        {
            return element.CompareTo(base[Count - 1]);
        }

        public override void Add(T element)
        {
            base.Insert(FindRightPosition(element), element);
        }

        public override void Insert(int index, T element)
        {
            if (!VerifyIfSortedAtInsertElement(index, element))
            {
                return;
            }

            base.Insert(index, element);
        }

        private bool VerifyIfSortedAtSetElement(int index, T element)
        {
            return GetValue(index - 1, element).CompareTo(element) <= 0 && element.CompareTo(GetValue(index + 1, element)) <= 0;
        }

        private bool VerifyIfSortedAtInsertElement(int index, T element)
        {
            return GetValue(index - 1, element).CompareTo(element) <= 0 && element.CompareTo(GetValue(index, element)) <= 0;
        }

        private int FindRightPosition(T element)
        {
            if (Count == 0)
            {
                return Count;
            }

            for (int i = 0; i < Count; i++)
            {
                if (element.CompareTo(base[i]) <= 0)
                {
                    return i;
                }
            }

            return Count;
        }

        private T GetValue(int index, T defaultValue) => (index < 0 || index > Count - 1) ? defaultValue : base[index];
    }
}
