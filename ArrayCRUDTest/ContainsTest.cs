using ArrayCRUD;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ArrayCRUDTest
{
    public class ContainsTest
    {
        [Fact]
        public void ContainsElement()
        {
            var sut = new IntArray();
            sut.Add(1);
            sut.Add(2);
            sut.Add(3);
            sut.Add(4);
            sut.Add(5);
            Assert.True(sut.Contains(2));
        }
        [Fact]
        public void NotContainsElement()
        {

            var sut = new IntArray();
            sut.Add(1);
            sut.Add(2);
            sut.Add(3);
            sut.Add(4);
            sut.Add(5);

            Assert.False(sut.Contains(9));
        }
    }
}
