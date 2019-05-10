using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using TinyExe;
using NUnit;
using NUnit.Framework;

namespace TinyExe.Tests
{
    /// <summary>
    /// Summary description for CalculationTests
    /// basic arithmitic tests
    /// </summary>
    [TestFixture]
    public class CalculationTests
    {

        [Test]
        public void TestMultiplicationLong()
        {
            double answer = Expression.Eval<double>("42*24");
            Assert.AreEqual(answer, 42*24);

        }

        [Test]
        public void TestMultiplicationLongDouble()
        {
            double answer = Expression.Eval<double>("42 % 25 * (2.4/0.31)");
            Assert.AreEqual(answer, 42 % 25 * (2.4/0.31));
        }

        [Test]
        public void TestMultiplicationLongLong()
        {
            double answer = Expression.Eval<double>("42.2 % 25.3 * (4/2)");
            Assert.AreEqual(answer, 42.2 % 25.3 * (4 / 2));
        }

        [Test]
        public void TestAdditionLongDouble()
        {
            double answer = Expression.Eval<double>("42 % 25 * (2.4-0.31)");
            Assert.AreEqual(answer, 42 % 25 * (2.4 - 0.31));
        }

        [Test]
        public void TestAdditionLongLong()
        {
            double answer = Expression.Eval<double>("42 % 25 * (4+2+(10-2))");
            Assert.AreEqual(answer, 42 % 25 * (4 + 2 + (10-2)));
        }

        [Test]
        public void TestSign()
        {
            double answer = Expression.Eval<double>("-25");
            Assert.AreEqual(answer, -25);
        }

        [Test]
        public void TestSignMult()
        {
            double answer = Expression.Eval<double>("42 * -25");
            Assert.AreEqual(answer, 42 * -25);
        }

        [Test]
        public void TestPower()
        {
            double answer = Expression.Eval<double>("42 ^ 4.3");
            Assert.AreEqual(answer, Math.Pow(42, 4.3));
        }

        [Test]
        public void TestPower3()
        {
            double answer = Expression.Eval<double>("2^3^4");
            Assert.AreEqual(answer, 4096);
        }


        [Test]
        public void TestFact()
        {
            double answer = Expression.Eval<double>("Fact(12)");
            Assert.AreEqual(answer, 479001600);
        }

    }
}
