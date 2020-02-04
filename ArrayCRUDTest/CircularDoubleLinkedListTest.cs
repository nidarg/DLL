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
            ArrayCRUD.LinkedListNode<string> first = listTest.First;
            ArrayCRUD.LinkedListNode<string> addedNode =new ArrayCRUD.LinkedListNode<string> ("nice");
            listTest.AddAfter(first, addedNode);
            ArrayCRUD.LinkedListNode<string> newAddedNode = listTest.First.Next;
            Assert.Contains("nice", listTest);
            Assert.Equal("nice", newAddedNode.Value);
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
        public void AddItemBeforeNode()
        {
            string[] words =
           { "the", "fox", "jumps", "over", "the", "dog" };
            CircularDoubleLinkedListCollection<string> listTest = new CircularDoubleLinkedListCollection<string>(words);
            ArrayCRUD.LinkedListNode<string> second = listTest.First.Next;
            listTest.AddBefore(second, "old");
            ArrayCRUD.LinkedListNode<string> addedNode = listTest.First.Next;
            Assert.Contains("old", listTest);
            Assert.Equal("old", addedNode.Value);
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
            ArrayCRUD.LinkedListNode<string> newAddedNode = listTest.First;
            Assert.Contains("nice", listTest);
            Assert.Equal("nice", newAddedNode.Value);
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
            Assert.Contains("nice", listTest);
            Assert.Equal("nice", newAddedNode.Value);
        }

        [Fact]
        public void FindNode()
        {
            string[] words =
           { "the", "fox", "jumps", "over", "the", "dog" };
            CircularDoubleLinkedListCollection<string> listTest = new CircularDoubleLinkedListCollection<string>(words);
            ArrayCRUD.LinkedListNode<string> foundNode = listTest.Find(listTest.Last.Previous.Value);
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
    }
}
