using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TinyExe;

namespace TinyExe.Tests
{
    /// <summary>
    /// Summary description for BinaryTests
    /// Tests all && and || operations
    /// </summary>
    [TestClass]
    public class BinaryTests
    {

        [TestMethod]
        public void TestAndTrue()
        {
            bool answer = Expression.Eval<bool>("5 > 4.3 && true");
            Assert.AreEqual(answer, 5 > 4.3 && true);
        }

        [TestMethod]
        public void TestAndOrFalse()
        {
            bool answer = Expression.Eval<bool>("5 < 4.3 && true || \"test\" != \"test\"");
            Assert.AreEqual(answer, 5 < 4.3 && true || "test" != "test");
        }

        [TestMethod]
        public void TestEqStringAndTrue()
        {
            bool answer = Expression.Eval<bool>("\"test\" = \"test\" && true");
            Assert.AreEqual(answer, "test" == "test" && true);
        }

        [TestMethod]
        public void TestConditional()
        {
            double answer = Expression.Eval<double>("\"test\" = \"te\" & \"st\" ? 42 : 52");
            Assert.AreEqual(answer, "test" == "test" ? 42 : 52);
        }

        [TestMethod]
        public void TestConditionalFalse()
        {
            double answer = Expression.Eval<double>("false ? 42 : 52");
            Assert.AreEqual(answer, false ? 42 : 52);
        }

    }
}
