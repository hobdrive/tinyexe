using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using TinyExe;

namespace TinyExe.Tests
{
    /// <summary>
    /// tests reading and interpreting the basic literals
    /// supports: string, bool and double
    /// </summary>
    [TestClass]
    public class LiteralTests
    {
        [TestMethod]
        public void TestStringLiteral()
        {
            string answer = Expression.Eval<string>("\"Herre\"");
            Assert.AreEqual(answer, "Herre");
        }

        [TestMethod]
        public void TestStringLiteralAsObject()
        {
            object answer = new Expression("\"Herre\"").Eval();
            Assert.AreEqual(answer.ToString(), "Herre");
        }

        [TestMethod]
        public void TestRealLiteral()
        {
            double answer = Expression.Eval<double>("3.141592");
            Assert.AreEqual(answer, 3.141592);
        }

        [TestMethod]
        public void TestRealLiteralAsObject()
        {
            object answer = Expression.Eval("3.141592");
            Assert.AreEqual((double)answer, 3.141592);
        }

        [TestMethod]
        public void TestIntegerLiteral()
        {
            double answer = Expression.Eval<double>("42");
            Assert.AreEqual(answer, 42);
        }

        [TestMethod]
        public void TestBoolLiteral()
        {
            bool answer = Expression.Eval<bool>("true");
            Assert.AreEqual(answer, true);
        }

        [TestMethod]
        public void TestHexLiteral()
        {
            double answer = Expression.Eval<double>("0x42"); 
            Assert.AreEqual(answer, 0x42);

            answer = Expression.Eval<double>("0xFF");
            Assert.AreEqual(answer, 0xFF);
        }


        [TestMethod]
        public void TestBoolLiteralNegate()
        {
            bool answer = Expression.Eval<bool>("!true");
            Assert.AreEqual(answer, false);
        }

        [TestMethod]
        public void TestBoolLiteralNegateIllegal()
        {
            bool answer = Expression.Eval<bool>("!42"); // not default is return false
            Assert.AreEqual(answer, false);
        }

        [TestMethod]
        public void TestBoolLiteralNegateIllegalObject()
        {
            object answer = Expression.Eval("!42"); // expect null because of error
            Assert.AreEqual(answer, null);
        }

    }
}
