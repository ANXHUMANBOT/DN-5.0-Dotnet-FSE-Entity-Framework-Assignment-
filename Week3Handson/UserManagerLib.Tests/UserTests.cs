using System;
using NUnit.Framework;
using UserManagerLib;

namespace UserManagerLib.Tests
{
    [TestFixture]
    public class UserTests
    {
        private User _user;

        [SetUp]
        public void Setup()
        {
            _user = new User();
        }

        [Test]
        public void CreateUser_ValidTenCharacterPan_CreatesUserSuccessfully()
        {
            var newUser = new User
            {
                FirstName = "John",
                LastName = "Doe",
                EmailId = "john.doe@example.com",
                PANCardNo = "ABCDE1234F"
            };

            Assert.DoesNotThrow(() => _user.CreateUser(newUser));
        }

        [TestCase(null)]
        [TestCase("")]
        public void CreateUser_NullOrEmptyPan_ThrowsNullReferenceException(string? pan)
        {
            var newUser = new User { PANCardNo = pan };
            Assert.Throws<NullReferenceException>(() => _user.CreateUser(newUser));
        }

        [TestCase("ABC123")]
        [TestCase("ABCDE12345F")]
        public void CreateUser_PanNotTenCharacters_ThrowsFormatException(string pan)
        {
            var newUser = new User { PANCardNo = pan };
            Assert.Throws<FormatException>(() => _user.CreateUser(newUser));
        }

        [Test]
        public void ValidatePANCardNumber_TenCharacterPan_ReturnsValid()
        {
            string result = _user.ValidatePANCardNumber("ABCDE1234F");
            Assert.That(result, Is.EqualTo("Valid"));
        }
    }
}