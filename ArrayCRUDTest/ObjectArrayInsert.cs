using ArrayCRUD;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ArrayCRUDTest
{
    public class ObjectArrayInsert
    {
        [Fact]
        public void IndexOfElement()
        {
            int val = 9;
            object objValue = val;
            var sut = new ObjectArrayCollection();
            var intArr = new int[] { 2, 3, 4 };
            sut.Add(0);
            sut.Add(true);
            sut.Add(3.4647);
            sut.Add("string");
            sut.Add(intArr);
            sut.Add(6);
            sut.Add(0);
            sut.Add(8);
            sut.Add(9);
            sut.Add(10);
            sut.Insert(1, objValue);
            Assert.Equal(1, sut.IndexOf(objValue));
        }
        [Fact]
        public void InsertAndResize()
        {
            var sut = new ObjectArrayCollection();
            var intArr = new int[] { 2, 3, 4 };
            sut.Add(0);
            sut.Add(true);
            sut.Add(3.4647);
            sut.Add("string");
            sut.Add(intArr);
            sut.Add(6);
            sut.Add(0);
            sut.Add(8);
            sut.Add(9);
            sut.Add(10);
            sut.Insert(3, true);
            Assert.Equal(4, sut.IndexOf("string"));
           

        }

        [Fact]
        public void CheckLengthAferInsertion()
        {
            var sut = new ObjectArrayCollection();
            var intArr = new int[] { 2, 3, 4 };
            sut.Add(0);
            sut.Add(true);
            sut.Add(3.4647);
            sut.Add("string");
            sut.Add(intArr);
            sut.Insert(1, 4);
            Assert.Equal(6, sut.Count);
        }
    }
}
