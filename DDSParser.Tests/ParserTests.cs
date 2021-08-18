using System.IO;
using System.Linq;
using Xunit;

namespace DDSParser.Tests
{
    public class ParserTests
    {
        [Fact]
        public void TestDDSFileParser()
        {
            var files = Directory
                .EnumerateFiles("files", "*.dds", SearchOption.TopDirectoryOnly)
                .ToList();
            Assert.NotEmpty(files);

            foreach (var file in files)
            {
                Assert.True(File.Exists(file), $"File {file} does not exist!");
                var ddsImage = new DDSImage(file);
            }
        }
    }
}
