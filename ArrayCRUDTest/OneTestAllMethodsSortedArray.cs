using ArrayCRUD;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ArrayCRUDTest
{
    public class OneTestAllMethodsSortedArray
    {
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
            sut.Add(10);       //- 0,1,2,3,4,6,7,8,9,10
            sut.Insert(5, 5);  //- 0,1,2,3,4,5,6,7,8,9,10
            sut.RemoveAt(10);  //- 0,1,2,3,4,5,6,7,8,9
            sut.Remove(8);      //- 0,1,2,3,4,5,6,7,9
            Assert.Equal(1, sut[1]); 
            Assert.Equal(5, sut[5]);
            Assert.Equal(9, sut[8]);
            Assert.True(sut.Contains(5));
            Assert.False(sut.Contains(8));
            Assert.Equal(3, sut.IndexOf(3));

        }

    }
}
