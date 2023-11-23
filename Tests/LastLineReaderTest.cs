using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogsReader;

namespace Tests
{
    public class LastLineReaderTest
    {
        private string path = "C:\\Users\\Kirill\\Desktop\\logs.txt";
        private LastLineReader reader;
        public LastLineReaderTest()
        {
            reader = new LastLineReader() ;       
        }

        [Fact]
        public void Read_ReadsLastLine()
        {
            //Arrange
            File.WriteAllText(path, "");
            File.WriteAllLines(path,new []{ "one","Two","three"});

            //Act
            var result = reader.Read(path) ;
            //Assert
            Assert.IsType<string>(result) ;
            Assert.Equal("three",result) ;
        }
        [Fact]
        public void Read_ReadsEmptyLine()
        {
            //Arrange
            File.WriteAllText(path, "");

            //Act
            var result = reader.Read(path);
            //Assert
            Assert.Null(result);
        }
        [Fact]
        public void Read_ReadsWrongFile()
        {
            //Arrange

            //Act

            //Assert
            Assert.Throws<FileNotFoundException>(() => reader.Read("wrong.txt"));
        }
    }
}
