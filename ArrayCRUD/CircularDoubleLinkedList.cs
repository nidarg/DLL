using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ArrayCRUD
{
    public class CircularDoubleLinkedListCollection<T> : ICollection<T>
    {
        internal LinkedListNode<T> Head;
        internal int CountValue;

        public CircularDoubleLinkedListCollection()
        {
        }

        public CircularDoubleLinkedListCollection(IEnumerable<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection));
            }

            foreach (T item in collection)
            {
                AddLast(item);
            }
        }

        public int Count
        {
            get { return CountValue; }
        }

        public LinkedListNode<T> First
        {
            get
            {
                return Head;
            }
        }

        public LinkedListNode<T> Last
        {
            get
            {
                return Head?.Previous;
            }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        void ICollection<T>.Add(T item)
        {
            AddLast(item);
        }

        public LinkedListNode<T> AddAfter(LinkedListNode<T> node, T item)
        {
            VerifyExistingNode(node);
            LinkedListNode<T> newNode = new LinkedListNode<T>(item, node.List);
            InsertAfter(node, newNode);
            return newNode;
        }

        public void AddAfter(LinkedListNode<T> node, LinkedListNode<T> newNode)
        {
           VerifyExistingNode(node);
           VerifyNewNode(newNode);
           InsertAfter(node, newNode);
           newNode.List = this;
        }

        public LinkedListNode<T> AddBefore(LinkedListNode<T> node, T item)
        {
            VerifyExistingNode(node);
            LinkedListNode<T> newNode = new LinkedListNode<T>(item, node.List);
            InsertBefore(node, newNode);
            if (node == Head)
            {
                Head = newNode;
            }

            return newNode;
        }

        public void AddBefore(LinkedListNode<T> node, LinkedListNode<T> newNode)
        {
            VerifyExistingNode(node);
            VerifyNewNode(newNode);
            InsertBefore(node, newNode);
            newNode.List = this;
            if (node != Head)
            {
                return;
            }

            Head = newNode;
        }

        public LinkedListNode<T> AddFirst(T item)
        {
            LinkedListNode<T> newNode = new LinkedListNode<T>(item, this);
            if (Head == null)
            {
                InsertToEmptyList(newNode);
            }
            else
            {
                InsertBefore(Head, newNode);
                Head = newNode;
            }

            return newNode;
        }

        public void AddFirst(LinkedListNode<T> newNode)
        {
            VerifyNewNode(newNode);
            if (Head == null)
            {
                InsertToEmptyList(newNode);
            }
            else
            {
                InsertBefore(Head, newNode);
                Head = newNode;
            }

            newNode.List = this;
        }

        public LinkedListNode<T> AddLast(T item)
        {
            LinkedListNode<T> newNode = new LinkedListNode<T>(item, this);
            if (Head == null)
            {
                InsertToEmptyList(newNode);
            }
            else
            {
                InsertBefore(Head, newNode);
            }

            return newNode;
        }

        public void AddLast(LinkedListNode<T> newNode)
        {
            VerifyNewNode(newNode);

            if (Head == null)
            {
                InsertToEmptyList(newNode);
            }
            else
            {
                InsertBefore(Head, newNode);
            }

            newNode.List = this;
        }

        public void Clear()
        {
            LinkedListNode<T> node = Head;
            while (node != null)
            {
                LinkedListNode<T> deletedNode = node;
                node = node.Next;
                deletedNode.List = null;
                deletedNode.Next = null;
                deletedNode.Previous = null;
            }

            Head = null;
            CountValue = 0;
        }

        public LinkedListNode<T> Find(T item)
        {
            return FindFirstNode(Head, item);
        }

        public LinkedListNode<T> FindLast(T item)
        {
            LinkedListNode<T> node = Head.Previous;
            return FindLastNode(node, item);
        }

        public IEnumerator<T> GetEnumerator()
        {
            LinkedListNode<T> current = Head;
            if (current != null)
            {
                do
                {
                    yield return current.Value;
                    current = current.Next;
                }
                while (current != Head);
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public bool Contains(T item)
        {
            return Find(item) != null;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array), "array can 't be null");
            }

            if (arrayIndex < 0 || arrayIndex > array.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(arrayIndex), "start index must be positive");
            }

            if (array.Length - arrayIndex < Count)
            {
                throw new ArgumentException("Not enough space to copy all elements");
            }

            LinkedListNode<T> node = Head;
            for (int i = 0; i < Count; i++)
            {
                array[i + arrayIndex] = node.Value;
                node = node.Next;
            }
        }

        public bool Remove(T item)
            {
            LinkedListNode<T> node = Find(item);
            if (node == null)
            {
                return false;
            }

            RemoveNode(node);
            return true;
        }

        public void Remove(LinkedListNode<T> node)
        {
            VerifyExistingNode(node);
            RemoveNode(node);
        }

        public void RemoveFirst()
        {
            if (Head == null)
            {
                throw new InvalidOperationException("Empty list");
            }

            RemoveNode(Head);
        }

        public void RemoveLast()
        {
            if (Head == null)
            {
                throw new InvalidOperationException("Empty list");
            }

            RemoveNode(Head.Previous);
        }

        private void VerifyExistingNode(LinkedListNode<T> node)
        {
            if (node == null)
            {
                throw new ArgumentNullException(nameof(node));
            }

            if (node.List == this)
            {
                return;
            }

            throw new InvalidOperationException("node doesn't belongs to this list");
        }

        private void VerifyNewNode(LinkedListNode<T> node)
            {
            if (node == null)
            {
                throw new ArgumentNullException(nameof(node));
            }

            if (node.List == null)
            {
                return;
            }

            throw new InvalidOperationException("node belongs to another list");
        }

        private void InsertAfter(LinkedListNode<T> node, LinkedListNode<T> newNode)
        {
            newNode.Next = node.Next;
            node.Next.Previous = newNode;
            newNode.Previous = node;
            node.Next = newNode;
            CountValue++;
        }

        private void InsertBefore(LinkedListNode<T> node, LinkedListNode<T> newNode)
        {
            newNode.Next = node;
            newNode.Previous = node.Previous;
            node.Previous.Next = newNode;
            node.Previous = newNode;
            CountValue++;
        }

        private void InsertToEmptyList(LinkedListNode<T> newNode)
        {
            newNode.Next = newNode;
            newNode.Previous = newNode;
            Head = newNode;
            CountValue++;
        }

        private LinkedListNode<T> FindFirstNode(LinkedListNode<T> node, T valueToCompare)
        {
            EqualityComparer<T> comparer = EqualityComparer<T>.Default;
            LinkedListNode<T> result = null;
            if (comparer.Equals(node.Value, valueToCompare))
            {
                return node;
            }
            else if (node.Next != Head)
            {
                return FindFirstNode(node.Next, valueToCompare);
            }

            return result;
        }

        private LinkedListNode<T> FindLastNode(LinkedListNode<T> node, T valueToCompare)
        {
            EqualityComparer<T> comparer = EqualityComparer<T>.Default;
            LinkedListNode<T> result = null;
            if (comparer.Equals(node.Value, valueToCompare))
            {
                return node;
            }
            else if (node.Previous != Head.Previous)
            {
                return FindLastNode(node.Previous, valueToCompare);
            }
            else
            {
                return result;
            }
        }

        private void RemoveNode(LinkedListNode<T> node)
        {
            if (node.Next == node)
            {
                Head = null;
            }
            else
            {
                node.Next.Previous = node.Previous;
                node.Previous.Next = node.Next;
                if
                    (Head == node)
                {
                    Head = node.Next;
                }
            }

            node.List = null;
            node.Next = null;
            node.Previous = null;
            CountValue--;
        }
    }
}
