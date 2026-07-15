using System.Collections.Generic;
using NUnit.Framework;
using Moq;
using MagicFilesLib;

namespace DirectoryExplorer.Tests
{
    [TestFixture]
    public class DirectoryExplorerTests
    {
        private readonly string _file1 = "file.txt";
        private readonly string _file2 = "file2.txt";

        private Mock<IDirectoryExplorer> _mockDirectoryExplorer;

        [OneTimeSetUp]
        public void Init()
        {
            _mockDirectoryExplorer = new Mock<IDirectoryExplorer>();
            _mockDirectoryExplorer
                .Setup(d => d.GetFiles(It.IsAny<string>()))
                .Returns(new List<string> { _file1, _file2 });
        }

        [TestCase]
        public void GetFiles_GivenPath_ReturnsExpectedFileCollection()
        {
            ICollection<string> files = _mockDirectoryExplorer.Object.GetFiles(@"C:\SomeFolder");

            Assert.That(files, Is.Not.Null);
            Assert.That(files.Count, Is.EqualTo(2));
            Assert.That(files, Does.Contain(_file1));
        }
    }
}