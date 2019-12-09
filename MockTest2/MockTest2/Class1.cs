using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MockTest2
{
    public class TestClass1
    {
        public TestClass1()
        {
        }

        public int TestFunc1(int n)
        {
            return n + 1;
        }
    }

    public class TestClass2
    {
        public TestClass2()
        {
        }

        public int TestFunc2(int n)
        {
            TestClass1 tc1 = new TestClass1();
            return tc1.TestFunc1(n) + 10;
        }
    }

}
