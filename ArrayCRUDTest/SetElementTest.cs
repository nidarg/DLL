using ArrayCRUD;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ArrayCRUDTest
{
    public class SetElementTest
    {
        [Fact]
        public void ChangeValueAtIndex()
        {
            var sut = new IntArray();
            sut.Add(1);
            sut.Add(2);
            sut.Add(3);
            sut.Add(4);
            sut.Add(0);
            sut[1] = 1;
            Assert.Equal(1,sut[1]);
        }

    }
}
