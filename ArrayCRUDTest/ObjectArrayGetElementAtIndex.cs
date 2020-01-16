using ArrayCRUD;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ArrayCRUDTest
{
    public class ObjectArrayGetElementAtIndex
    {
        [Fact]
        public void GetElementsAtIndex()
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
            
        }
    }
}
