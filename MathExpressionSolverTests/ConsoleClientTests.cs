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
    class ConsoleClientTests
    {
        private readonly string expr1 = "3+5";

        ConsoleClient sut;

        public ConsoleClientTests()
        {
            sut = new ConsoleClient();
        }

        [Test]
        public void ValidateExpression_SimpleExpressionTest()
        {

            sut.Expression = expr1;
            Assert.That(sut.ValidateExpression(), Is.True);
        }


        [Test]
        public void ValidateExpression_InvalidExpressionTest1()
        {
            sut.Expression = "This expression should return false";
            Assert.That(sut.ValidateExpression(), Is.False);
        }

        [Test]
        public void ValidateExpression_InvalidExpressionTest2()
        {
            sut.Expression = "4*b9+3/7";
            Assert.That(sut.ValidateExpression(), Is.False);
        }

        [Test]
        public void IntegrationTest_ExpressionWithSpaces()
        {
            sut.Expression = "5+6/2-1";
            Assert.AreEqual(sut.getExpressionResult(), 7);
        }


    }
}
