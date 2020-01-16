using ArrayCRUD;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ArrayCRUDTest
{
    public class InsertTest
    {
        [Fact]
        public void IndexOfElement()
        {
            var sut = new IntArray();
            sut.Add(1);
            sut.Add(2);
            sut.Add(3);
            sut.Add(4);
            sut.Add(5);
            sut.Insert(1, 9);
            Assert.Equal(1, sut.IndexOf(9));
        }
        [Fact]
        public void InsertAndResize()
        {
            var sut = new IntArray();
            sut.Add(1);
            sut.Add(2);
            sut.Add(3);
            sut.Add(4);
            sut.Insert(1, 9);
            Assert.Equal(1, sut.IndexOf(9));
            Assert.Equal(5, sut.Count);
            
        }

        [Fact]
        public void CheckLengthAferInsertion()
        {
            var sut = new IntArray();
            sut.Add(1);
            sut.Add(2);
            sut.Add(3);
            sut.Add(4);
            sut.Add(5);
            sut.Insert(1, 4);
            Assert.Equal(6, sut.Count);
        }
    }
}
