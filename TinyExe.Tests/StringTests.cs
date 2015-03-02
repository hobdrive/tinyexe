using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TinyExe;

namespace TinyExe.Tests
{
    /// <summary>
    /// Summary description for StringTests
    /// Tests strings and concats of several types
    /// </summary>
    [TestClass]
    public class StringTests
    {

        [TestMethod]
        public void TestConcatExpAndTrue()
        {
            // demonstrates precedence of & over >
            // so "5" > "4.3true"
            bool answer = Expression.Eval<bool>("5 > 4.3 & \"true\"");
            Assert.AreEqual(answer, true);
        }

        [TestMethod]
        public void TestHelloWorld()
        {
            string answer = Expression.Eval<string>("\"Hello\" & \" \" & \"World\"");
            Assert.AreEqual(answer, "Hello World");
        }

        [TestMethod]
        public void TestLeftHelloWorld()
        {
            string answer = Expression.Eval<string>("Left(\"Hello\" & \" \" & \"World\";5)");
            Assert.AreEqual(answer, "Hello");
        }

        [TestMethod]
        public void TestRightHelloWorld()
        {
            string answer = Expression.Eval<string>("Right(\"Hello\" & \" \" & \"World\";5)");
            Assert.AreEqual(answer, "World");
        }
        
        [TestMethod]
        public void TestMidHelloWorld()
        {
            string answer = Expression.Eval<string>("Mid(\"Hello\" & \" \" & \"World\";4;3)");
            Assert.AreEqual(answer, "o W");
        }

        [TestMethod]
        public void TestLenHelloWorld()
        {
            double answer = Expression.Eval<double>("Len(\"Hello\" & \" \" & \"World\")");
            Assert.AreEqual(answer, 11);
        }

        [TestMethod]
        public void TestValPi()
        {
            double answer = Expression.Eval<double>("val(\"3,1415\")");
            Assert.AreEqual(answer, 3.1415);
        }

    }
}
