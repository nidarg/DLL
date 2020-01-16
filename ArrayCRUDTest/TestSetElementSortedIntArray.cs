using ArrayCRUD;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ArrayCRUDTest
{
    public class TestSetElementSortedIntArray
    {
        [Fact]
        public void ChangeValueAtIndexUnsortedArray()
        {
            var sut = new SortedIntArray();
            sut.Add(1);
            sut.Add(3);
            sut.Add(4);
            sut.Add(5);
            
            sut[1] = 0;
            Assert.Equal(3, sut[1]);
        }
        [Fact]
        public void ChangeValueAtIndexSortedArray()
        {
            var sut = new SortedIntArray();
            sut.Add(1);
            sut.Add(3);
            sut.Add(4);
            sut.Add(5);

            sut[1] = 2;
            Assert.Equal(2, sut[1]);
        }
    }
}
