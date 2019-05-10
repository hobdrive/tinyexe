using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using TinyExe;
using NUnit.Framework;

namespace TinyExe.Tests
{
    /// <summary>
    /// Summary description for BinaryTests
    /// Tests all && and || operations
    /// </summary>
    [TestFixture]
    public class BinaryTests
    {

        [Test]
        public void TestAndTrue()
        {
            bool answer = Expression.Eval<bool>("5 > 4.3 && true");
            Assert.AreEqual(answer, 5 > 4.3 && true);
        }

        [Test]
        public void TestAndOrFalse()
        {
            bool answer = Expression.Eval<bool>("5 < 4.3 && true || \"test\" != \"test\"");
            Assert.AreEqual(answer, 5 < 4.3 && true || "test" != "test");

            answer = Expression.Eval<bool>("5 < 4.3 and true or \"test\" != \"test\"");
            Assert.AreEqual(answer, 5 < 4.3 && true || "test" != "test");
        }

        [Test]
        public void TestEqStringAndTrue()
        {
            bool answer = Expression.Eval<bool>("\"test\" = \"test\" && true");
            Assert.AreEqual(answer, "test" == "test" && true);
        }

        [Test]
        public void TestConditional()
        {
            double answer = Expression.Eval<double>("\"test\" = \"te\" & \"st\" ? 42 : 52");
            Assert.AreEqual(answer, "test" == "test" ? 42 : 52);
        }

        [Test]
        public void TestConditionalFalse()
        {
            double answer = Expression.Eval<double>("false ? 42 : 52");
            Assert.AreEqual(answer, false ? 42 : 52);
        }

    }
}
