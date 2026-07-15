using NUnit.Framework;
using Moq;
using PlayersManagerLib;

namespace PlayerManager.Tests
{
    [TestFixture]
    public class PlayerManagerTests
    {
        private Mock<IPlayerMapper> _mockPlayerMapper;

        [OneTimeSetUp]
        public void Init()
        {
            _mockPlayerMapper = new Mock<IPlayerMapper>();
            _mockPlayerMapper
                .Setup(m => m.IsPlayerNameExistsInDb(It.IsAny<string>()))
                .Returns(false);
        }

        [TestCase("Virat")]
        public void RegisterNewPlayer_NewPlayerName_ReturnsPlayerWithExpectedAttributes(string name)
        {
            Player player = Player.RegisterNewPlayer(name, _mockPlayerMapper.Object);

            Assert.That(player.Name, Is.EqualTo(name));
            Assert.That(player.Age, Is.EqualTo(23));
            Assert.That(player.Country, Is.EqualTo("India"));
            Assert.That(player.NoOfMatches, Is.EqualTo(30));
        }

        [Test]
        public void RegisterNewPlayer_EmptyName_ThrowsArgumentException()
        {
            Assert.Throws<System.ArgumentException>(
                () => Player.RegisterNewPlayer("", _mockPlayerMapper.Object));
        }

        [Test]
        public void RegisterNewPlayer_NameAlreadyExists_ThrowsArgumentException()
        {
            var existingMock = new Mock<IPlayerMapper>();
            existingMock.Setup(m => m.IsPlayerNameExistsInDb(It.IsAny<string>())).Returns(true);

            Assert.Throws<System.ArgumentException>(
                () => Player.RegisterNewPlayer("Rohit", existingMock.Object));
        }
    }
}