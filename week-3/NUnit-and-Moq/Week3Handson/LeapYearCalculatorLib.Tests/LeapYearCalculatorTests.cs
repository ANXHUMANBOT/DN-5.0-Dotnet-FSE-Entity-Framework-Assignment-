using NUnit.Framework;
using LeapYearCalculatorLib;

namespace LeapYearCalculatorLib.Tests
{
    [TestFixture]
    public class LeapYearCalculatorTests
    {
        private LeapYearCalculator _leapYearCalculator;

        [SetUp]
        public void Setup()
        {
            _leapYearCalculator = new LeapYearCalculator();
        }

        [TestCase(2000)]
        [TestCase(2024)]
        [TestCase(1996)]
        public void IsLeapYear_GivenLeapYear_ReturnsOne(int year)
        {
            int actual = _leapYearCalculator.IsLeapYear(year);
            Assert.That(actual, Is.EqualTo(1));
        }

        [TestCase(1900)]
        [TestCase(2023)]
        [TestCase(1999)]
        public void IsLeapYear_GivenNonLeapYear_ReturnsZero(int year)
        {
            int actual = _leapYearCalculator.IsLeapYear(year);
            Assert.That(actual, Is.EqualTo(0));
        }

        [TestCase(1752)]
        [TestCase(10000)]
        [TestCase(1000)]
        public void IsLeapYear_GivenYearOutOfValidRange_ReturnsMinusOne(int year)
        {
            int actual = _leapYearCalculator.IsLeapYear(year);
            Assert.That(actual, Is.EqualTo(-1));
        }

        [TestCase(1753)]
        [TestCase(9999)]
        public void IsLeapYear_GivenBoundaryYear_DoesNotReturnMinusOne(int year)
        {
            int actual = _leapYearCalculator.IsLeapYear(year);
            Assert.That(actual, Is.Not.EqualTo(-1));
        }
    }
}