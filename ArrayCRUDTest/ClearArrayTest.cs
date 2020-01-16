using ArrayCRUD;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ArrayCRUDTest
{
    public class ClearArrayTest
    {
        [Fact]
        public void ClearTest()
        {
            var sut = new IntArray();
            sut.Add(1);
            sut.Add(2);
            sut.Add(3);
            sut.Add(4);
            sut.Add(5);
            sut.Clear();
            Assert.Equal(0, sut.Count);
        }
    }
}
