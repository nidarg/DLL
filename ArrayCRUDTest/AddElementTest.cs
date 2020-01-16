using ArrayCRUD;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ArrayCRUDTest
{
    public class AddElementTest
    {

        [Fact]
        public void AddValue()
        {

            var sut = new IntArray();
            sut.Add(0);
            sut.Add(2);
            sut.Add(3);
            Assert.Equal(2, sut[1]);
            Assert.Equal(3, sut.Count);
        }

        [Fact]
        public void AddValueAndResize()
        {
            
            var sut = new IntArray();
            sut.Add(0);
            sut.Add(2);
            sut.Add(3);
            sut.Add(4);
            sut.Add(5);
            sut.Add(6);
            sut.Add(0);
            sut.Add(8);
            sut.Add(9);
            sut.Add(10);

            Assert.Equal(3, sut[2]);
            Assert.Equal(10, sut.Count);
           
        }

      
    }
}
