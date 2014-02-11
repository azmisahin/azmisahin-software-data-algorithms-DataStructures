using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataStructures.Test
{
    [TestClass]
    public class StackTest
    {
        [TestMethod]
        public void StackPushTest()
        {
            Collections.Stack stack = new Collections.Stack();
            stack.Push("azmi");
            stack.Push("bilgi@azmisahin.com");
            stack.Push(5548777858);



            object expected = 5548777858;
            object actual = stack.Pop();

            Assert.AreEqual(expected, actual);
        }
    }
}
