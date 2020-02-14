using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ArrayCRUD
{
    public class CircularDoubleLinkedListCollection<T> : ICollection<T>
    {
        internal int CountValue;
        private readonly LinkedListNode<T> head;

        public CircularDoubleLinkedListCollection()
        {
            this.head = new LinkedListNode<T>();
            head.Next = head;
            head.Previous = head;
        }

        public CircularDoubleLinkedListCollection(IEnumerable<T> collection)
        {
            this.head = new LinkedListNode<T>(default(T));
            head.Next = head;
            head.Previous = head;
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
                return head.Next;
            }
        }

        public LinkedListNode<T> Last
        {
            get
            {
                return head.Previous;
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

        public LinkedListNode<T> AddBefore(LinkedListNode<T> node, T item)
        {
            VerifyExistingNode(node);
            LinkedListNode<T> newNode = new LinkedListNode<T>(item, node.List);
            InsertBefore(node, newNode);
            Last.Next = First;
            First.Previous = Last;
            return newNode;
        }

        public void AddBefore(LinkedListNode<T> node, LinkedListNode<T> newNode)
        {
            VerifyExistingNode(node);
            VerifyNewNode(newNode);
            InsertBefore(node, newNode);
            Last.Next = First;
            First.Previous = Last;
            newNode.List = this;
        }

        public LinkedListNode<T> AddFirst(T item)
        {
            LinkedListNode<T> newNode = new LinkedListNode<T>(item, this);
            InsertBefore(First, newNode);
            Last.Next = First;
            First.Previous = Last;
            CountValue++;
            return newNode;
        }

        public void AddFirst(LinkedListNode<T> newNode)
        {
            VerifyNewNode(newNode);
            InsertBefore(First, newNode);
            Last.Next = First;
            First.Previous = Last;
            CountValue++;
            newNode.List = this;
        }

        public LinkedListNode<T> AddLast(T item)
        {
            LinkedListNode<T> newNode = new LinkedListNode<T>(item, this);
            InsertBefore(head, newNode);
            Last.Next = First;
            CountValue++;
            return newNode;
        }

        public void AddLast(LinkedListNode<T> newNode)
        {
            VerifyNewNode(newNode);
            InsertBefore(head, newNode);
            Last.Next = First;
            First.Previous = Last;
            CountValue++;
            newNode.List = this;
        }

        public LinkedListNode<T> AddAfter(LinkedListNode<T> node, T item)
        {
            VerifyExistingNode(node);
            LinkedListNode<T> newNode = new LinkedListNode<T>(item, node.List);
            if (node != head.Previous)
            {
                InsertBefore(node.Next, newNode);
            }
            else
            {
                InsertBefore(head, newNode);
                Last.Next = First;
                First.Previous = Last;
            }

            return newNode;
        }

        public void AddAfter(LinkedListNode<T> node, LinkedListNode<T> newNode)
        {
            VerifyExistingNode(node);
            VerifyNewNode(newNode);
            if (node != head.Previous)
            {
                InsertBefore(node.Next, newNode);
            }
            else
            {
                InsertBefore(head, newNode);
                Last.Next = First;
                First.Previous = Last;
            }
        }

        public void Clear()
        {
            head.Next = head;
            head.Previous = head;
            CountValue = 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (LinkedListNode<T> t = head; t != head.Previous; t = t.Next)
            {
                yield return t.Next.Value;
            }
        }

        public IEnumerable<LinkedListNode<T>> GetNodeEnumerator()
        {
            for (LinkedListNode<T> t = head; t != head.Previous; t = t.Next)
            {
                yield return t.Next;
            }
        }

        public IEnumerable<T> GetReverseEnumerator()
        {
            for (LinkedListNode<T> t = head; t != head.Next; t = t.Previous)
            {
                yield return t.Previous.Value;
            }
        }

        public IEnumerable<LinkedListNode<T>> GetReverseNodeEnumerator()
        {
            for (LinkedListNode<T> t = head; t != head.Next; t = t.Previous)
            {
                yield return t.Previous;
            }
        }

        public LinkedListNode<T> Find(T item)
            {
            EqualityComparer<T> comparer = EqualityComparer<T>.Default;
            foreach (LinkedListNode<T> t in this.GetNodeEnumerator())
            {
                if (comparer.Equals(t.Value, item))
                {
                    return t;
                }
            }

            return null;
            }

        public LinkedListNode<T> FindLast(T item)
        {
            {
                EqualityComparer<T> comparer = EqualityComparer<T>.Default;
                foreach (LinkedListNode<T> t in this.GetReverseNodeEnumerator())
                {
                    if (comparer.Equals(t.Value, item))
                    {
                        return t;
                    }
                }

                return null;
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

            LinkedListNode<T> node = head.Next;
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
            if (EmptyList())
            {
                throw new InvalidOperationException("Empty list");
            }

            RemoveNode(head.Next);
        }

        public void RemoveLast()
        {
            if (EmptyList())
            {
                throw new InvalidOperationException("Empty list");
            }

            RemoveNode(head.Previous);
        }

        private void VerifyExistingNode(LinkedListNode<T> node)
        {
            if (node == null)
            {
                throw new ArgumentNullException(nameof(node));
            }
            else if (node.List != this)
            {
                throw new InvalidOperationException("node doesn't belongs to this list");
            }
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

        private void InsertBefore(LinkedListNode<T> node, LinkedListNode<T> newNode)
        {
            newNode.Next = node;
            newNode.Previous = node.Previous;
            node.Previous.Next = newNode;
            node.Previous = newNode;
        }

        private bool EmptyList()
        {
            return head.Previous == head && head.Next == head;
        }

        private void RemoveNode(LinkedListNode<T> node)
        {
            if (node.Next == node)
            {
                head.Next = head;
                head.Previous = head;
            }
            else
            {
                node.Next.Previous = node.Previous;
                node.Previous.Next = node.Next;
                if
                    (head.Next == node)
                {
                    head.Next = node.Next;
                }

                if
                    (head.Previous == node)
                {
                    head.Previous = node.Previous;
                }
            }

            node.List = null;
            node.Next = null;
            node.Previous = null;
            CountValue--;
        }
    }
}
