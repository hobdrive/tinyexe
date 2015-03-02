using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TinyExe;

namespace TinyExe.Tests
{
    /// <summary>
    /// Summary description for FunctionTests
    /// Tests with various functions
    /// </summary>
    [TestClass]
    public class DynamicFunctionTests
    {

        [TestMethod]
        public void TestDynBasicStuff()
        {
            // test recursive definition and evaluation
            Context.Default.Reset();
            Expression.Eval("f(x) := x*x/2");
            double answer = Expression.Eval<double>("f(4)");
            Assert.AreEqual(answer, 4 * 4 / 2.0);


        }

        [TestMethod]
        public void TestDynTextFormatter()
        {
            // test recursive definition and evaluation
            Context.Default.Reset();
            Expression.Eval("Int2Hex(t) := format(\"{0:X}\";int(t))");
            string answer = Expression.Eval<string>("Int2Hex(255.42)");
            Assert.AreEqual(answer, "FF");
        }

        [TestMethod]
        public void TestDynFacultyRecursion()
        {
            // test recursive definition and evaluation
            Context.Default.Reset();
            Expression.Eval("fac(n) := n = 0 ? 1 : fac(n-1)*n");
            double answer = Expression.Eval<double>("fac(6)");
            Assert.AreEqual(answer, 6*5*4*3*2.0);
        }


        [TestMethod]
        public void TestDynScopeCheck()
        {
            Context.Default.Reset();
            Expression.Eval("X := 42"); // declare global
            Expression.Eval("f(x) := X^x"); // declare function with dependency on global
            Expression.Eval("g(x;y) := x*y"); // declare function relying on x
            double answer = Expression.Eval<double>("f(2)/g(4;5)"); // define x for different scopes for f and g
            Assert.AreEqual(answer, (42*42) / (4*5.0));
        }

        [TestMethod]
        public void TestDynFunctionInFunction()
        {
            Context.Default.Reset();
            Expression.Eval("f(x) := x^x"); // declare function with dependency on global
            Expression.Eval("g(x) := x+2"); // declare function relying on x
            double answer = Expression.Eval<double>("f(g(3))"); // define x for different scopes for f and g
            Assert.AreEqual(answer, 3125.0);
        }

    }
}
