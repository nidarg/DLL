﻿using ArrayCRUD;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ArrayCRUDTest
{
    public class ObjectArrayIEnumerableTest
    {

        [Fact]
        public void VerifyEnumerator()
        {

            var sut = new ObjectArrayCollection();
            sut.Add(0);
            sut.Add(2.657);
            sut.Add("string");
            var enumerator = sut.GetEnumerator();
            enumerator.MoveNext();
            Assert.Equal(0, enumerator.Current);
            enumerator.MoveNext();
            enumerator.MoveNext();
            Assert.Equal("string", enumerator.Current);           
        }
    }
}
