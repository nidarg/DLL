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
            this.head = new LinkedListNode<T>();
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

        public LinkedListNode<T> AddAfter(LinkedListNode<T> node, T item)
        {
            VerifyExistingNode(node);
            if (node == head.Previous)
            {
                return this.AddLast(item);
            }

            LinkedListNode<T> newNode = new LinkedListNode<T>(item, node.List);
            return this.InsertBefore(node.Next, newNode);
        }

        public void AddAfter(LinkedListNode<T> node, LinkedListNode<T> newNode)
        {
           VerifyExistingNode(node);
           VerifyNewNode(newNode);
           InsertBefore(node.Next, newNode);
           newNode.List = this;
        }

        public LinkedListNode<T> AddBefore(LinkedListNode<T> node, T item)
        {
            VerifyExistingNode(node);
            if (node == head.Next)
            {
                return this.AddFirst(item);
            }

            LinkedListNode<T> newNode = new LinkedListNode<T>(item, node.List);
            return this.InsertBefore(node, newNode);
        }

        public void AddBefore(LinkedListNode<T> node, LinkedListNode<T> newNode)
        {
            VerifyExistingNode(node);
            VerifyNewNode(newNode);
            if (node == head.Next)
            {
               this.AddFirst(newNode);
            }

            InsertBefore(node, newNode);
            newNode.List = this;
        }

        public LinkedListNode<T> AddFirst(T item)
        {
            LinkedListNode<T> newNode = new LinkedListNode<T>(item, this);
            AddAsFirst(newNode);
            CountValue++;
            return newNode;
        }

        public void AddFirst(LinkedListNode<T> newNode)
        {
            VerifyNewNode(newNode);
            AddAsFirst(newNode);
            CountValue++;
            newNode.List = this;
        }

        public LinkedListNode<T> AddLast(T item)
        {
            LinkedListNode<T> newNode = new LinkedListNode<T>(item, this);
            AddAsLast(newNode);
            CountValue++;
            return newNode;
        }

        public void AddLast(LinkedListNode<T> newNode)
        {
            VerifyNewNode(newNode);
            AddAsLast(newNode);
            CountValue++;
            newNode.List = this;
        }

        public void Clear()
        {
            LinkedListNode<T> node = head.Next;
            while (node != head.Next)
            {
                LinkedListNode<T> deletedNode = node;
                node = node.Next;
                deletedNode.List = null;
                deletedNode.Next = null;
                deletedNode.Previous = null;
            }

            head.Next = head;
            head.Previous = head;
            CountValue = 0;
        }

        public LinkedListNode<T> Find(T item)
            {
            LinkedListNode<T> node = head.Next;
            EqualityComparer<T> comparer = EqualityComparer<T>.Default;
            if (node == null)
            {
                return null;
            }

            if (item != null)
            {
                do
                {
                    if (comparer.Equals(node.Value, item))
                    {
                        return node;
                    }

                    node = node.Next;
                }
                while (node != head.Next);
            }
            else
            {
                do
                {
                    if (node.Value == null)
                    {
                        return node;
                    }

                    node = node.Next;
                }
                while (node != head.Next);
            }

            return null;
            }

        public LinkedListNode<T> FindLast(T item)
        {
            {
                LinkedListNode<T> node = head.Previous;
                EqualityComparer<T> comparer = EqualityComparer<T>.Default;
                if (node == null)
                {
                    return null;
                }

                if (item != null)
                {
                    do
                    {
                        if (comparer.Equals(node.Value, item))
                        {
                            return node;
                        }

                        node = node.Previous;
                    }
                    while (node != head.Previous);
                }
                else
                {
                    do
                    {
                        if (node.Value == null)
                        {
                            return node;
                        }

                        node = node.Previous;
                    }
                    while (node != head.Previous);
                }

                return null;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            LinkedListNode<T> current = head.Next;
            if (current != null)
            {
                do
                {
                    yield return current.Value;
                    current = current.Next;
                }
                while (current != head.Next);
            }
        }

        public IEnumerable<T> GetReverseEnumerator()
            {
            LinkedListNode<T> current = head.Previous;
            if (current == null)
            {
                yield break;
            }

            do
            {
                yield return current.Value;
                current = current.Previous;
            }
            while (current != head.Previous);
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

        private LinkedListNode<T> InsertBefore(LinkedListNode<T> node, LinkedListNode<T> newNode)
        {
            node.Previous.Next = newNode;
            newNode.Previous = node.Previous;
            newNode.Next = node;
            node.Previous = newNode;
            return newNode;
        }

        private void AddAsFirst(LinkedListNode<T> newNode)
        {
            newNode.Previous = head.Previous;
            newNode.Next = head.Next;
            head.Next = newNode;
            head.Previous.Next = newNode;
        }

        private void AddAsLast(LinkedListNode<T> newNode)
        {
            head.Previous.Next = newNode;
            newNode.Next = head.Next;
            newNode.Previous = head.Previous;
            head.Previous = newNode;
        }

        private bool EmptyList()
        {
            return head.Previous == head && head.Next == head;
        }

        private void InsertToEmptyList(LinkedListNode<T> newNode)
        {
            newNode.Next = newNode;
            newNode.Previous = newNode;
            head.Next = newNode;
            head.Previous = newNode;
        }

        private LinkedListNode<T> FindLastNode(LinkedListNode<T> node, T valueToCompare)
        {
            EqualityComparer<T> comparer = EqualityComparer<T>.Default;
            LinkedListNode<T> result = null;
            if (comparer.Equals(node.Value, valueToCompare))
            {
                return node;
            }
            else if (node.Previous != head.Previous)
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
