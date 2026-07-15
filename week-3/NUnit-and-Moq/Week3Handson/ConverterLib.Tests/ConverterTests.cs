using NUnit.Framework;
using Moq;
using ConverterLib;
using CurrencyConverterApp;

namespace ConverterLib.Tests
{
    [TestFixture]
    public class ConverterTests
    {
        private Mock<IDollarToEuroExchangeRateFeed> _mockExchangeRateFeed;
        private Converter _converter;

        [SetUp]
        public void Setup()
        {
            _mockExchangeRateFeed = new Mock<IDollarToEuroExchangeRateFeed>();
        }

        [Test]
        public void USDToEuro_GivenDollarAmount_ReturnsConvertedEuroAmount()
        {
            _mockExchangeRateFeed.Setup(feed => feed.GetActualUSDollarValue()).Returns(0.85);
            _converter = new Converter(_mockExchangeRateFeed.Object);

            double actual = _converter.USDToEuro(100);

            Assert.That(actual, Is.EqualTo(85.0));
        }

        [Test]
        public void USDToEuro_ZeroDollarAmount_ReturnsZero()
        {
            _mockExchangeRateFeed.Setup(feed => feed.GetActualUSDollarValue()).Returns(0.9);
            _converter = new Converter(_mockExchangeRateFeed.Object);

            double actual = _converter.USDToEuro(0);

            Assert.That(actual, Is.EqualTo(0));
        }

        [Test]
        public void USDToEuro_Always_CallsExchangeRateFeedExactlyOnce()
        {
            _mockExchangeRateFeed.Setup(feed => feed.GetActualUSDollarValue()).Returns(0.85);
            _converter = new Converter(_mockExchangeRateFeed.Object);

            _converter.USDToEuro(50);

            _mockExchangeRateFeed.Verify(feed => feed.GetActualUSDollarValue(), Times.Once);
        }

        [TestCase(0, 273.15)]
        [TestCase(100, 373.15)]
        public void CelsiusToKelvin_GivenCelsius_ReturnsKelvin(double celsius, double expected)
        {
            _converter = new Converter(_mockExchangeRateFeed.Object);
            Assert.That(_converter.CelsiusToKelvin(celsius), Is.EqualTo(expected));
        }
    }
}