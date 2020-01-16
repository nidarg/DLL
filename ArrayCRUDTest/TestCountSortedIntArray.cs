using ArrayCRUD;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ArrayCRUDTest
{
    public class TestCountSortedIntArray
    {
        [Fact]
        public void CountElements()
        {
            var sut = new SortedIntArray();
            sut.Add(1);
            sut.Add(2);
            sut.Add(3);
            sut.Add(4);
            sut.Add(5);
            Assert.Equal(5, sut.Count);
           
        }
    }
}
