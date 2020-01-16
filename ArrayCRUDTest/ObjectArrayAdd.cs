using ArrayCRUD;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ArrayCRUDTest
{
    public class ObjectArrayAdd
    {

        [Fact]
        public void AddValue()
        {

            var sut = new ObjectArrayCollection();
            sut.Add(0);
            sut.Add(2.657);
            sut.Add("string");
            Assert.Equal("string", sut[2]);
            Assert.Equal(3, sut.Count);
        }

        [Fact]
        public void AddValueAndResize()
        {
            var intArr = new int[] { 2, 3, 4 };
            var sut = new ObjectArrayCollection();
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

            Assert.Equal(intArr, sut[4]);
            Assert.Equal(10, sut.Count);
        }
    }
}
