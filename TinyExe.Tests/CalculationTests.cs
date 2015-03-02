using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TinyExe;

namespace TinyExe.Tests
{
    /// <summary>
    /// Summary description for CalculationTests
    /// basic arithmitic tests
    /// </summary>
    [TestClass]
    public class CalculationTests
    {

        [TestMethod]
        public void TestMultiplicationLong()
        {
            double answer = Expression.Eval<double>("42*24");
            Assert.AreEqual(answer, 42*24);

        }

        [TestMethod]
        public void TestMultiplicationLongDouble()
        {
            double answer = Expression.Eval<double>("42 % 25 * (2.4/0.31)");
            Assert.AreEqual(answer, 42 % 25 * (2.4/0.31));
        }

        [TestMethod]
        public void TestMultiplicationLongLong()
        {
            double answer = Expression.Eval<double>("42.2 % 25.3 * (4/2)");
            Assert.AreEqual(answer, 42.2 % 25.3 * (4 / 2));
        }

        [TestMethod]
        public void TestAdditionLongDouble()
        {
            double answer = Expression.Eval<double>("42 % 25 * (2.4-0.31)");
            Assert.AreEqual(answer, 42 % 25 * (2.4 - 0.31));
        }

        [TestMethod]
        public void TestAdditionLongLong()
        {
            double answer = Expression.Eval<double>("42 % 25 * (4+2+(10-2))");
            Assert.AreEqual(answer, 42 % 25 * (4 + 2 + (10-2)));
        }

        [TestMethod]
        public void TestSign()
        {
            double answer = Expression.Eval<double>("-25");
            Assert.AreEqual(answer, -25);
        }

        [TestMethod]
        public void TestSignMult()
        {
            double answer = Expression.Eval<double>("42 * -25");
            Assert.AreEqual(answer, 42 * -25);
        }

        [TestMethod]
        public void TestPower()
        {
            double answer = Expression.Eval<double>("42 ^ 4.3");
            Assert.AreEqual(answer, Math.Pow(42, 4.3));
        }

        [TestMethod]
        public void TestPower3()
        {
            double answer = Expression.Eval<double>("2^3^4");
            Assert.AreEqual(answer, 4096);
        }


        [TestMethod]
        public void TestFact()
        {
            double answer = Expression.Eval<double>("Fact(12)");
            Assert.AreEqual(answer, 479001600);
        }

    }
}
