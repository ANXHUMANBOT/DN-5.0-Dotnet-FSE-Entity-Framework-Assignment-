using System;
using NUnit.Framework;
using UtilLib;

namespace UtilLib.Tests
{
    [TestFixture]
    public class UrlHostNameParserTests
    {
        private UrlHostNameParser _parser;

        [SetUp]
        public void Setup()
        {
            _parser = new UrlHostNameParser();
        }

        [TestCase("http://www.google.com/search", "www.google.com")]
        [TestCase("https://www.cognizant.com/about", "www.cognizant.com")]
        [TestCase("http://example.com", "example.com")]
        public void ParseHostName_ValidHttpUrl_ReturnsHostName(string url, string expectedHost)
        {
            string actual = _parser.ParseHostName(url);
            Assert.That(actual, Is.EqualTo(expectedHost));
        }

        [TestCase("ftp://www.google.com")]
        [TestCase("smtp://mail.server.com")]
        public void ParseHostName_InvalidProtocol_ThrowsFormatException(string url)
        {
            var ex = Assert.Throws<FormatException>(() => _parser.ParseHostName(url));
            Assert.That(ex.Message, Is.EqualTo("Url is not in correct format"));
        }
    }
}