using ArrayCRUD;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ArrayCRUDTest
{
    public class TestRemoveSortedIntArray
    {

        [Fact]
        public void VerifyCountAfterRemove()
        {
            var sut = new SortedIntArray();
            sut.Add(1);
            sut.Add(2);
            sut.Add(3);
            sut.Add(4);
            sut.Add(5);
            sut.Remove(2);
            Assert.Equal(4, sut.Count);
        }
        [Fact]
        public void VerifyElementsAfterRemove()
        {
            var sut = new SortedIntArray();
            sut.Add(1);
            sut.Add(2);
            sut.Add(3);
            sut.Add(4);
            sut.Add(5);
            sut.Remove(2);
            Assert.Equal(3, sut[1]);
            Assert.Equal(4, sut[2]);
        }
    }
}
