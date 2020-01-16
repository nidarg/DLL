using ArrayCRUD;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ArrayCRUDTest
{
    public class RemoveAtIndexTest
    {
        [Fact]
        public void VerifyCountAfterRemove()
        {
            var sut = new IntArray();
            sut.Add(1);
            sut.Add(2);
            sut.Add(3);
            sut.Add(4);
            sut.Add(5);
            sut.RemoveAt(2);
            Assert.Equal(4, sut.Count);
        }
        [Fact]
        public void VerifyElementsAfterRemove()
        {
            var sut = new IntArray();
            sut.Add(1);
            sut.Add(2);
            sut.Add(3);
            sut.Add(4);
            sut.Add(5);
            sut.RemoveAt(1);
            Assert.Equal(4, sut[2]);
            Assert.Equal(5, sut[3]);
        }

        
    }
}
