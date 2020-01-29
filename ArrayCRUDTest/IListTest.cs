using ArrayCRUD;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ArrayCRUDTest
{
    public class IListTest
    {
        [Fact]
        public void AddValueAndResizeSortedArray()
        {

            var sut = new IListCollection<int>();
            sut.Add(0);
            sut.Add(2);
            sut.Add(3);
            sut.Add(4);
            sut.Add(1);
            sut.Add(6);
            sut.Add(7);
            sut.Add(8);
            sut.Add(9);
            sut.Add(10);       //- 0,2,3,4,1,6,7,8,9,10
            sut.Insert(5, 5);  //- 0,2,3,4,1,5,6,7,8,9,10
            sut.RemoveAt(10);  //- 0,2,3,4,5,6,7,8,9
            sut.Remove(8);      //- 0,2,3,4,5,6,7,9
            Assert.Equal(2, sut[1]);
            Assert.Equal(5, sut[5]);
            Assert.Equal(7, sut[7]);
            Assert.Equal(9, sut[8]);

            Assert.Equal(2, sut.IndexOf(3));
        }

        [Fact]
        public void TestExceptionAtGetAtWrongIndex()
        {

            var sut = new IListCollection<int>();
            sut.Add(0);
            sut.Add(2);
            sut.Add(3);
            Assert.Throws<ArgumentOutOfRangeException>(() => sut[5]);
        }

        [Fact]
        public void TestExceptionAtSetAtWrongIndex()
        {

            var sut = new IListCollection<int>();
            sut.Add(0);
            sut.Add(2);
            sut.Add(3);
            Assert.Throws<ArgumentOutOfRangeException>(() => sut[5] = 3);
        }

        [Fact]
        public void TestExceptionAtInsertAtWrongIndex()
        {

            var sut = new IListCollection<int>();
            sut.Add(0);
            sut.Add(2);
            sut.Add(3);
            Action act = () => sut.Insert(5, 5);
            var exception = Assert.Throws<ArgumentOutOfRangeException>(act);
            Assert.Equal("index", exception.ParamName);
        }

        [Fact]
        public void TestCopyToArgumentNullException()
        {

            var sut = new IListCollection<int>();
            sut.Add(0);
            sut.Add(2);
            sut.Add(3);
            int[] arr = null;
            Action act = () => sut.CopyTo(arr, 0);
            var exception = Assert.Throws<ArgumentNullException>(act);
            Assert.Equal("array", exception.ParamName);
        }

        [Fact]
        public void TestCopyToArgumentOutOfRangeException()
        {

            var sut = new IListCollection<int>();
            sut.Add(0);
            sut.Add(2);
            sut.Add(3);
            int[] arr = new int[10];
            Action act = () => sut.CopyTo(arr, -1);
            var exception = Assert.Throws<ArgumentOutOfRangeException>(act);
            Assert.Equal("arrayIndex", exception.ParamName);

        }

        [Fact]
        public void TestCopyToArgumentException()
        {

            var sut = new IListCollection<int>();
            sut.Add(0);
            sut.Add(2);
            sut.Add(3);
            int[] arr = new int[2];
            Action act = () => sut.CopyTo(arr, 1);
            var exception = Assert.Throws<ArgumentException>(act);
            Assert.Equal("Not enough space to copy all elements", exception.Message);
        }

        [Fact]
        public void TestNotSuportedExceptionAtAdd()
        {

            var sut = new IListCollection<int>();
            sut.Add(0);
            sut.Add(2);
            sut.Add(3);
            sut.ReadOnly();

            Action act = () => sut.Add(2);
            var exception = Assert.Throws<NotSupportedException>(act);
            Assert.Equal("The collection is read only", exception.Message);
        }

        [Fact]
        public void TestNotSuportedExceptionAtClear()
        {

            var sut = new IListCollection<int>();
            sut.Add(0);
            sut.Add(2);
            sut.Add(3);
            sut.ReadOnly();

            Action act = () => sut.Clear();
            var exception = Assert.Throws<NotSupportedException>(act);
            Assert.Equal("The collection is read only", exception.Message);
        }

        [Fact]
        public void TestNotSuportedExceptionAtInsert()
        {

            var sut = new IListCollection<int>();
            sut.Add(0);
            sut.Add(2);
            sut.Add(3);
            sut.ReadOnly();

            Action act = () => sut.Insert(1, 4);
            var exception = Assert.Throws<NotSupportedException>(act);
            Assert.Equal("The collection is read only", exception.Message);
        }

        [Fact]
        public void TestNotSuportedExceptionAtRemove()
        {

            var sut = new IListCollection<int>();
            sut.Add(0);
            sut.Add(2);
            sut.Add(3);
            sut.ReadOnly();

            Action act = () => sut.Remove(2);
            var exception = Assert.Throws<NotSupportedException>(act);
            Assert.Equal("The collection is read only", exception.Message);
        }

        [Fact]
        public void TestArgumentOutOfRangeExceptionAtRemoveAt()
        {

            var sut = new IListCollection<int>();
            sut.Add(0);
            sut.Add(2);
            sut.Add(3);
            Action act = () => sut.RemoveAt(5);
            var exception = Assert.Throws<ArgumentOutOfRangeException>(act);
            Assert.Equal("index", exception.ParamName);

        }

        [Fact]
        public void TestNotSuportedExceptionAtRemoveAt()
        {

            var sut = new IListCollection<int>();
            sut.Add(0);
            sut.Add(2);
            sut.Add(3);
            sut.ReadOnly();

            Action act = () => sut.RemoveAt(2);
            var exception = Assert.Throws<NotSupportedException>(act);
            Assert.Equal("The collection is read only", exception.Message);
        }

    }
}
