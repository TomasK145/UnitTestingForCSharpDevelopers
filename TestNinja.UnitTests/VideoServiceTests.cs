using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Mocking;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class VideoServiceTests
    {
        private VideoService _videoService;
        private Mock<IFileReader> fileReader;

        [SetUp]
        public void SetUp()
        {
            fileReader = new Mock<IFileReader>(); //inicializacia mock objektu
            _videoService = new VideoService(fileReader.Object);
        }

        [Test]
        public void ReadVideoTitle_EmptyFile_ReturnError()
        {
            fileReader.Setup(fr => fr.Read("video.txt")).Returns("{\"Title\":\"error\"}"); //definovanie co sa ma stat ak je volana metoda Read s atributom "video.txt" --> vrati string "error"            

            var result = _videoService.ReadVideoTitle();

            Assert.That(result, Does.Contain("error").IgnoreCase);
        }
    }
}
