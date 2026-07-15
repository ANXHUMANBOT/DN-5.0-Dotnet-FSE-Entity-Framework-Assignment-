using System;
using NUnit.Framework;
using CalcLibrary;

namespace CalcLibrary.Tests
{
    [TestFixture]
    public class CalculatorTests
    {
        private SimpleCalculator _calculator;

        [SetUp]
        public void Setup()
        {
            _calculator = new SimpleCalculator();
        }

        [TearDown]
        public void Teardown()
        {
            _calculator = null;
        }

        [TestCase(2, 3, 5)]
        [TestCase(-2, -3, -5)]
        [TestCase(0, 0, 0)]
        public void Addition_TwoNumbers_ReturnsSum(double a, double b, double expected)
        {
            double actual = _calculator.Addition(a, b);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase(10, 4, 6)]
        [TestCase(4, 10, -6)]
        [TestCase(0, 0, 0)]
        public void Subtraction_TwoNumbers_ReturnsDifference(double a, double b, double expected)
        {
            double actual = _calculator.Subtraction(a, b);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase(3, 4, 12)]
        [TestCase(-3, 4, -12)]
        [TestCase(0, 5, 0)]
        public void Multiplication_TwoNumbers_ReturnsProduct(double a, double b, double expected)
        {
            double actual = _calculator.Multiplication(a, b);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase(10, 2, 5)]
        [TestCase(9, 3, 3)]
        [TestCase(-10, 2, -5)]
        public void Division_TwoNumbers_ReturnsQuotient(double a, double b, double expected)
        {
            double actual = _calculator.Division(a, b);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Division_ByZero_ThrowsArgumentException()
        {
            try
            {
                _calculator.Division(10, 0);
                Assert.Fail("Division by zero");
            }
            catch (ArgumentException ex)
            {
                Assert.That(ex.Message, Is.EqualTo("Second Parameter Can't be Zero"));
            }
        }

        [Test]
        public void TestAddAndClear()
        {
            double expected = _calculator.Addition(5, 5);
            double actual = _calculator.GetResult;
            Assert.That(actual, Is.EqualTo(expected));

            _calculator.AllClear();

            Assert.That(_calculator.GetResult, Is.EqualTo(0));
        }
    }
}