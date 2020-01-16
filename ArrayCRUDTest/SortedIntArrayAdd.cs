using ArrayCRUD;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ArrayCRUDTest
{
    public class SortedIntArrayAdd
    { 
            [Fact]
            public void AddValueInSortedArray()
            {

                var sut = new SortedIntArray();
                sut.Add(0);
                sut.Add(2);
                sut.Add(3);
                Assert.Equal(2, sut[1]);
                Assert.Equal(3, sut.Count);
            }

            [Fact]
            public void AddValueAndResizeSortedArray()
            {

                var sut = new SortedIntArray();
                sut.Add(0);
                sut.Add(2);
                sut.Add(3);
                sut.Add(4);
                sut.Add(1);
                sut.Add(6);
                sut.Add(7);
                sut.Add(8);
                sut.Add(9);
                sut.Add(10);

            Assert.Equal(1, sut[1]);
            Assert.Equal(2, sut[2]);
            Assert.Equal(3, sut[3]);
            Assert.Equal(4, sut[4]);
            Assert.Equal(10, sut.Count);
                
            }

    }
    
}
