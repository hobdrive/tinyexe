using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TinyExe;

namespace TinyExe.Tests
{
    /// <summary>
    /// Summary description for EqualityTests
    /// tests all types of comparisons
    /// </summary>
    [TestClass]
    public class EqualityTests
    {

        [TestMethod]
        public void TestLargerThan()
        {
            bool answer = Expression.Eval<bool>("5 > 4.3");
            Assert.AreEqual(answer, 5 > 4.3);

            answer = Expression.Eval<bool>("\"5\" > \"4.3\"");
            Assert.AreEqual(answer, 5 > 4.3);
        }

        [TestMethod]
        public void TestSmallerThan()
        {
            bool answer = Expression.Eval<bool>("5 < 4.3");
            Assert.AreEqual(answer, 5 < 4.3);

            answer = Expression.Eval<bool>("\"5\" < \"4.3\"");
            Assert.AreEqual(answer, 5 < 4.3);
        }

        [TestMethod]
        public void TestLargerEqThan()
        {
            bool answer = Expression.Eval<bool>("5 >= 4.3");
            Assert.AreEqual(answer, 5 >= 4.3);

            answer = Expression.Eval<bool>("\"5\" >= \"4.3\"");
            Assert.AreEqual(answer, 5 >= 4.3);
        }

        [TestMethod]
        public void TestSmallerEqThan()
        {
            bool answer = Expression.Eval<bool>("5 <= 4.3");
            Assert.AreEqual(answer, 5 <= 4.3);

            answer = Expression.Eval<bool>("\"5\" <= \"4.3\"");
            Assert.AreEqual(answer, 5 <= 4.3);
        }

        [TestMethod]
        public void TestEq()
        {
            bool answer = Expression.Eval<bool>("5 = 4.3");
            Assert.AreEqual(answer, 5 == 4.3);

            answer = Expression.Eval<bool>("\"5\" = \"4.3\"");
            Assert.AreEqual(answer, 5 == 4.3);
        }

        [TestMethod]
        public void TestNotEq()
        {
            bool answer = Expression.Eval<bool>("5 != 4.3");
            Assert.AreEqual(answer, 5 != 4.3);

            answer = Expression.Eval<bool>("\"5\" != \"4.3\"");
            Assert.AreEqual(answer, 5 != 4.3);
        }

        [TestMethod]
        public void TestEqTrue()
        {
            bool answer = Expression.Eval<bool>("5<6 = 6<9");
            Assert.AreEqual(answer, 5<6 == 6<9);
        }

        [TestMethod]
        public void TestNotEqTrue()
        {
            bool answer = Expression.Eval<bool>("5<6 != 11<9");
            Assert.AreEqual(answer, 5 < 6 != 11 < 9);
        }

        [TestMethod]
        public void TestEqEq()
        {
            bool answer = Expression.Eval<bool>("5 = 6 != 6"); // should give semantical error really - types are incorrect
            Assert.AreEqual(answer, true);
        }
    }
}
