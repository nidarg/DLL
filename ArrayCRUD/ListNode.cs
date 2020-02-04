using System;
using System.Collections.Generic;
using System.Text;

namespace ArrayCRUD
{
    public class LinkedListNode<T>
    {
        public LinkedListNode(T item)
        {
            this.Value = item;
        }

        public LinkedListNode(T item, CircularDoubleLinkedListCollection<T> list)
        {
            this.Value = item;
            List = list;
        }

        public CircularDoubleLinkedListCollection<T> List { get; internal set; }

        public T Value { get; private set; }

        public LinkedListNode<T> Next { get; internal set; }

        public LinkedListNode<T> Previous { get; internal set; }
    }
}
