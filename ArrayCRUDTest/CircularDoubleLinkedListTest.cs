using ArrayCRUD;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ArrayCRUDTest
{
    public class CircularDoubleLinkedListTest
    {
        [Fact]
        public void AddLastToEmptyList()
        {
           
            CircularDoubleLinkedListCollection<string> listTest = new CircularDoubleLinkedListCollection<string>();
            listTest.AddLast("first");
            Assert.Equal(1, listTest.Count);
            Assert.True(listTest.Contains("first"));
        }

        [Fact]
        public void AddItemAsLastNode()
        {
            string[] words =
           { "the", "fox", "jumps", "over", "the", "dog" };
            CircularDoubleLinkedListCollection<string> listTest = new CircularDoubleLinkedListCollection<string>(words);
            Assert.Equal("dog", listTest.Last.Value);
            Assert.Equal("the", listTest.Last.Next.Value);
        }

        [Fact]
        public void AddLastNode()
        {
            string[] words =
           { "the", "fox", "jumps", "over", "the", "dog" };
            CircularDoubleLinkedListCollection<string> listTest = new CircularDoubleLinkedListCollection<string>(words);
            ArrayCRUD.LinkedListNode<string> addedNode = new ArrayCRUD.LinkedListNode<string>("last added node");
            listTest.AddLast(addedNode);
            Assert.Equal("last added node", listTest.Last.Value);
            Assert.Equal("the", listTest.Last.Next.Value);
            Assert.Equal("last added node", listTest.First.Previous.Value);
        }

        [Fact]
        public void AddNodeToCollection()
        {
            string[] words =
           { "the", "fox", "jumps", "over", "the", "dog" };
            CircularDoubleLinkedListCollection<string> listTest = new CircularDoubleLinkedListCollection<string>(words);
            ICollection<string> icoll = listTest;
            icoll.Add("rhinoceros");
            Assert.Equal(7, icoll.Count);
            Assert.True(icoll.Contains("rhinoceros"));
        }

        [Fact]
        public void AddItemAfterLastNode()
        {
            string[] words =
           { "the", "fox", "jumps", "over", "the", "dog" };
            CircularDoubleLinkedListCollection<string> listTest = new CircularDoubleLinkedListCollection<string>(words);
            listTest.AddAfter(listTest.Last, "old");
            Assert.Equal("old", listTest.Last.Value);
            Assert.Equal("dog", listTest.Last.Previous.Value);
            Assert.Equal("the", listTest.Last.Next.Value);
        }

        [Fact]
        public void AddItemAfterNode()
        {
            string[] words =
           { "the", "fox", "jumps", "over", "the", "dog" };
            CircularDoubleLinkedListCollection<string> listTest = new CircularDoubleLinkedListCollection<string>(words);
            ArrayCRUD.LinkedListNode<string> first = listTest.First;
            listTest.AddAfter(first, "old");
            ArrayCRUD.LinkedListNode<string> addedNode = listTest.First.Next;
            Assert.Contains("old", listTest);
            Assert.Equal("old", addedNode.Value);
        }

        [Fact]
        public void AddItemAfterNodeArgumentNullException()
        {
            string[] words =
           { "the", "fox", "jumps", "over", "the", "dog" };
            CircularDoubleLinkedListCollection<string> listTest = new CircularDoubleLinkedListCollection<string>(words);
            ArrayCRUD.LinkedListNode<string> node = null;
            Action act = () => listTest.AddAfter(node, "old");
            var exception = Assert.Throws<ArgumentNullException>(act);
            Assert.Equal("node", exception.ParamName);
        }

        [Fact]
        public void AddItemAfterNodeInvalidOperationException()
        {
            string[] anotherListElements =
         { "crazy", "lazy"};
            string[] words =
           { "the", "fox", "jumps", "over", "the", "dog" };
            CircularDoubleLinkedListCollection<string> listTest = new CircularDoubleLinkedListCollection<string>(words);
            CircularDoubleLinkedListCollection<string> anotherList = new CircularDoubleLinkedListCollection<string>(anotherListElements);
            ArrayCRUD.LinkedListNode<string> node = anotherList.First;
            Action act = () => listTest.AddAfter(node, "old");
            var exception = Assert.Throws<InvalidOperationException>(act);
            Assert.Equal("node doesn't belongs to this list", exception.Message);
        }

        [Fact]
        public void AddNodeAfterNode()
        {
            string[] words =
           { "the", "fox", "jumps", "over", "the", "dog" };
            CircularDoubleLinkedListCollection<string> listTest = new CircularDoubleLinkedListCollection<string>(words);
            listTest.AddAfter(listTest.Last, "nice");
            Assert.Contains("nice", listTest);
            Assert.Equal("nice", listTest.Last.Value);
            Assert.Equal("dog", listTest.Last.Previous.Value);
            Assert.Equal("the", listTest.Last.Next.Value);
        }

        [Fact]
        public void AddNodeAfterNodeInvalidOperationException()
        {
            string[] anotherListElements =
        { "crazy", "lazy"};
            string[] words =
           { "the", "fox", "jumps", "over", "the", "dog" };
            CircularDoubleLinkedListCollection<string> listTest = new CircularDoubleLinkedListCollection<string>(words);
            CircularDoubleLinkedListCollection<string> anotherList = new CircularDoubleLinkedListCollection<string>(anotherListElements);
            ArrayCRUD.LinkedListNode<string> addedNode = anotherList.First;
            Action act = () => listTest.AddAfter(listTest.First, addedNode);
            var exception = Assert.Throws<InvalidOperationException>(act);
            Assert.Equal("node belongs to another list", exception.Message);
        }

        [Fact]
        public void AddItemBeforeFirstNode()
        {
            string[] words =
           { "the", "fox", "jumps"};
            CircularDoubleLinkedListCollection<string> list = new CircularDoubleLinkedListCollection<string>(words);
            list.AddBefore(list.First, "old");
            Assert.Equal("old", list.First.Value);
            Assert.Equal("the", list.First.Next.Value);
            Assert.Equal("jumps", list.First.Previous.Value);
            Assert.Equal("old", list.Last.Next.Value);
        }

        [Fact]
        public void AddItemBeforeNode()
        {
            string[] words =
           { "the", "fox", "jumps", "over", "the", "dog" };
            CircularDoubleLinkedListCollection<string> listTest = new CircularDoubleLinkedListCollection<string>(words);
            listTest.AddBefore(listTest.First.Next, "old");
            Assert.Contains("old", listTest);
            Assert.Equal("old", listTest.First.Next.Value);
            Assert.Equal("the", listTest.First.Value);
            Assert.Equal("fox", listTest.First.Next.Next.Value);
        }

        [Fact]
        public void AddNodeBeforeNode()
        {
            string[] words =
           { "the", "fox", "jumps", "over", "the", "dog" };
            CircularDoubleLinkedListCollection<string> listTest = new CircularDoubleLinkedListCollection<string>(words);
            ArrayCRUD.LinkedListNode<string> second = listTest.First.Next;
            ArrayCRUD.LinkedListNode<string> addedNode = new ArrayCRUD.LinkedListNode<string>("nice");
            listTest.AddBefore(second, addedNode);
            ArrayCRUD.LinkedListNode<string> newAddedNode = listTest.First.Next;
            Assert.Contains("nice", listTest);
            Assert.Equal("nice", newAddedNode.Value);
        }

        [Fact]
        public void AddNodeFirst()
        {
            string[] words =
           { "the", "fox", "jumps", "over", "the", "dog" };
            CircularDoubleLinkedListCollection<string> listTest = new CircularDoubleLinkedListCollection<string>(words);
            ArrayCRUD.LinkedListNode<string> addedNode = new ArrayCRUD.LinkedListNode<string>("nice");
            listTest.AddFirst(addedNode);
            Assert.Equal("nice", listTest.First.Value);
            Assert.Equal("the", listTest.First.Next.Value);
            Assert.Equal("nice", listTest.Last.Next.Value);
            Assert.Equal("dog", listTest.First.Previous.Value);
        }

        [Fact]
        public void AddNodeLast()
        {
            string[] words =
           { "the", "fox", "jumps", "over", "the", "dog" };
            CircularDoubleLinkedListCollection<string> listTest = new CircularDoubleLinkedListCollection<string>(words);
            ArrayCRUD.LinkedListNode<string> addedNode = new ArrayCRUD.LinkedListNode<string>("nice");
            listTest.AddLast(addedNode);
            ArrayCRUD.LinkedListNode<string> newAddedNode = listTest.Last;
            Assert.Equal("nice", listTest.Last.Value);
            Assert.Equal("the", listTest.Last.Next.Value);
            Assert.Equal("dog", listTest.Last.Previous.Value);
        }

        [Fact]
        public void ClearList()
        {
            string[] words =
           { "the", "fox", "jumps", "over", "the", "dog" };
            CircularDoubleLinkedListCollection<string> listTest = new CircularDoubleLinkedListCollection<string>(words);
            listTest.Clear();
            Assert.Equal(0, listTest.Count);
            listTest.AddLast("first element in an empty list");
            Assert.Equal("first element in an empty list", listTest.First.Next.Value);
        }

        [Fact]
        public void FindNode()
        {
            string[] words =
           { "the", "fox", "jumps", "over", "the", "dog" };
            CircularDoubleLinkedListCollection<string> listTest = new CircularDoubleLinkedListCollection<string>(words);
            ArrayCRUD.LinkedListNode<string> foundNode = listTest.Find("the");
            Assert.Equal("the", foundNode.Value);
        }

        [Fact]
        public void FindLastNode()
        {
            string[] words =
           { "the", "fox", "jumps", "over", "jumps",  "the", "dog" };
            CircularDoubleLinkedListCollection<string> listTest = new CircularDoubleLinkedListCollection<string>(words);
            ArrayCRUD.LinkedListNode<string> foundNode = listTest.FindLast("jumps");
            Assert.Equal(listTest.Last.Previous.Previous.Value, foundNode.Value);
        }

        [Fact]
        public void CopyToArray()
        {
            string[] words =
           { "the", "fox", "jumps", "over", "jumps",  "the", "dog" };
            CircularDoubleLinkedListCollection<string> listTest = new CircularDoubleLinkedListCollection<string>(words);
            string[] arrayToCopy = new string[listTest.Count];
            listTest.CopyTo(arrayToCopy, 0);
            Assert.Equal(7, arrayToCopy.Length);
            Assert.Equal("jumps", arrayToCopy[2]);
        }

        [Fact]
        public void TestCopyToArgumentNullException()
        {

            string[] words =
         { "the", "fox", "jumps", "over", "jumps",  "the", "dog" };
            CircularDoubleLinkedListCollection<string> listTest = new CircularDoubleLinkedListCollection<string>(words);
            string[] arr = null;
            Action act = () => listTest.CopyTo(arr, 0);
            var exception = Assert.Throws<ArgumentNullException>(act);
            Assert.Equal("array", exception.ParamName);
        }

        [Fact]
        public void TestCopyToArgumentOutOfRangeException()
        {

            string[] words =
         { "the", "fox", "jumps", "over", "jumps",  "the", "dog" };
            CircularDoubleLinkedListCollection<string> listTest = new CircularDoubleLinkedListCollection<string>(words);
            string[] arr = new string[listTest.Count];
            Action act = () => listTest.CopyTo(arr, -1);
            var exception = Assert.Throws<ArgumentOutOfRangeException>(act);
            Assert.Equal("arrayIndex", exception.ParamName);

        }

        [Fact]
        public void TestCopyToArgumentException()
        {

            string[] words =
        { "the", "fox", "jumps", "over", "jumps",  "the", "dog" };
            CircularDoubleLinkedListCollection<string> listTest = new CircularDoubleLinkedListCollection<string>(words);
            string[] arr = new string[2];
            Action act = () => listTest.CopyTo(arr, 1);
            var exception = Assert.Throws<ArgumentException>(act);
            Assert.Equal("Not enough space to copy all elements", exception.Message);
        }

        [Fact]
        public void RemoveItem()
        {
            string[] words =
           { "the", "fox", "jumps", "over", "jumps",  "the", "dog" };
            CircularDoubleLinkedListCollection<string> listTest = new CircularDoubleLinkedListCollection<string>(words);
            Assert.True(listTest.Remove("dog"));
            Assert.False(listTest.Remove("lazy"));
        }

        [Fact]
        public void RemoveFirst()
        {
            string[] words =
           { "the", "fox", "jumps", "over", "jumps",  "the", "dog" };
            CircularDoubleLinkedListCollection<string> listTest = new CircularDoubleLinkedListCollection<string>(words);
            listTest.RemoveFirst();
            Assert.Equal("fox", listTest.First.Value);
        }

        [Fact]
        public void RemoveFirstInvalidOperationException()
        {
            CircularDoubleLinkedListCollection<string> listTest = new CircularDoubleLinkedListCollection<string>();
            Action act = () => listTest.RemoveFirst();
            var exception = Assert.Throws<InvalidOperationException>(act);
            Assert.Equal("Empty list", exception.Message);
        }

        [Fact]
        public void RemoveLast()
        {
            string[] words =
           { "the", "fox", "jumps", "over", "jumps",  "the", "dog" };
            CircularDoubleLinkedListCollection<string> listTest = new CircularDoubleLinkedListCollection<string>(words);
            listTest.RemoveLast();
            Assert.Equal("the", listTest.Last.Value);
        }

        // n am folosit AddBefore la celelalte metode pt ca am VerifyExistingNode si mi arunca exceptia Invalid operation
        // daca nu foloseam la celelalte metode VerifyExistingNode nu respectam ruleset ul
        // la AddAfter trebuie facuta distinctie intre adugarea dupa ultimul element sau altul
        // la InsertBefore nu se poate stabili in cadrul metodei legatura First.Previous = Last pentru ca mi ia elementul 
        //          care era First inainte de inserare si practic nu se face legatura corecta
    }
}
