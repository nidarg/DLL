using ArrayCRUD;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ArrayCRUDTest
{
    public class TestInsertSortedArray
    {
        [Fact]
        public void IndexOfElement()
        {
            var sut = new SortedIntArray();
            sut.Add(1);
            sut.Add(2);
            sut.Add(3);
           
            sut.Insert(0, 0);
            Assert.Equal(0, sut.IndexOf(0));
        }
        [Fact]
        public void InsertAndResize()
        {
            var sut = new SortedIntArray();
            sut.Add(1);
            sut.Add(3);
            sut.Add(4);
            sut.Add(5);
            sut.Insert(1, 2);
            Assert.Equal(1, sut.IndexOf(2));
            Assert.Equal(5, sut.Count);
           
        }

        [Fact]
        public void CheckLengthAferInsertionNotSorted()
        {
            var sut = new SortedIntArray();
            sut.Add(1);
            sut.Add(2);
            sut.Add(3);
            sut.Add(4);
            sut.Add(5);
            sut.Insert(1, 4);
            Assert.Equal(5, sut.Count);
        }
    }
}
