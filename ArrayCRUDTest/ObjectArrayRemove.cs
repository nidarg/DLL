using ArrayCRUD;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ArrayCRUDTest
{
    public class ObjectArrayRemove
    {
        [Fact]
        public void VerifyCountAfterRemove()
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
            sut.Remove(true);
            Assert.Equal(9, sut.Count);
        }
        [Fact]
        public void VerifyElementsAfterRemove()
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
            sut.Remove(true);
            Assert.Equal("string", sut[2]);
            Assert.Equal(intArr, sut[3]);
        }
    }
}
