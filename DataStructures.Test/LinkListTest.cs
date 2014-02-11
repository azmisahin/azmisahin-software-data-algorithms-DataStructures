using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using DataStructures;

namespace DataStructures.Test
{
    [TestClass]
    public class LinkListTest
    {
        /// <summary>
        /// Sample Test
        /// </summary>
        [TestMethod]
        public void LinkList_ParametreTesti()
        {
            string[] sample = {"azmi", "sahin","com"};
            
            LinkList target = new LinkList(sample);
            
            int expected = sample.Length;
            int actual = target._List.Count;
            
            Assert.AreEqual(expected,actual);
        }
    }
}
