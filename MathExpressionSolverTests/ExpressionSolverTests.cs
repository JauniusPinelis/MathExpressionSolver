using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using MathExpressionSolver;

namespace ExpressionParserTests
{
    [TestFixture]
    public class ExpressionSolverTests
    {
        ExpressionSolver sut;

        public ExpressionSolverTests()
        {
            sut = new ExpressionSolver();
        }

        [Test]
        public void CalculateExpressionResult_SimpleTest1()
        {
            var expression = "3+5";

            Assert.AreEqual(sut.CalculateExpressionResult(expression), 8);
        }

        [Test]
        public void CalculateExpressionResult_SimpleTest2()
        {
            var testExpression = "3+5+9";
            Assert.AreEqual(sut.CalculateExpressionResult(testExpression), 17);
        }

        [Test]
        public void CalculateExpressionResult_SimpleTest3()
        {
            var testExpression = "2*2";
            Assert.AreEqual(sut.CalculateExpressionResult(testExpression), 4);
        }

        [Test]
        public void CalculateExpressionResult_TestingProduct()
        {
            var testExpression = "2*2-2*3";
            Assert.AreEqual(sut.CalculateExpressionResult(testExpression), -2);
        }

        [Test]
        public void CalculateExpressionResult_TestingProduct2()
        {
            var testExpression = "2+2-2*3";
            Assert.AreEqual(sut.CalculateExpressionResult(testExpression), -2);
        }

        [Test]
        public void CalculateExpressionResult_ComplexTest()
        {
            var testExpression = "3*4+3*2*4/6-2";
            Assert.AreEqual(sut.CalculateExpressionResult(testExpression), 14);
        }
    }
}
