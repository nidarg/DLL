using ArrayCRUD;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ArrayCRUDTest
{
    public class GetElement
    {
        [Fact]
        public void getElementAtIndex()
        {

            var sut = new IntArray();
            sut.Add(1);
            sut.Add(2);
            sut.Add(3);
            sut.Add(4);
            sut.Add(5);
            Assert.Equal(2, sut[1]);
        }

    }
}
