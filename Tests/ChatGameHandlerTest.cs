using LogsReader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class ChatGameHandlerTest
    {
        private ChatGameHandler _handler;
        public ChatGameHandlerTest()
        {
            _handler = new ChatGameHandler();
        }

        [Fact]
        public void Handle_WithWrongFormat_ReturnEmptyString()
        {
            //Arrange
            string logline = "Test  ";
            string pattern = @"(\d+\s*[+*\/-]\s*\d+)";
            //Act
            var result = _handler.Handle(logline, pattern);
            //Assert
            Assert.IsType<string>(result);
            Assert.Equal("", result);
        }
        [Fact]
        public void Handle_WithExpression_ReturnExpressionResult()
        {
            //Arrange
            string logline = "Guess expression 5 + 2 ";
            string pattern = @"(\d+\s*[+*\/-]\s*\d+)";
            //Act
            var result =_handler.Handle(logline, pattern);
            //Assert
            Assert.IsType<string>(result);
            Assert.Equal("7", result);
        }
        [Fact]
        public void Handle_WithNoExpression_ReturnEmptyString()
        {
            //Arrange
            string logline = "Guess expression  ";
            string pattern = @"(\d+\s*[+*\/-]\s*\d+)";
            //Act
            var result = _handler.Handle(logline, pattern);
            //Assert
            Assert.IsType<string>(result);
            Assert.Equal("", result);

        }
        [Fact]
        public void  Handle_WithWord_ReturnQuizResult()
        {
            string logline = "Guess word AAA ";
            string pattern = @"(\d+\s*[+*\/-]\s*\d+)";
            //Act
            var result = _handler.Handle(logline, pattern);
            //Assert
            Assert.IsType<string>(result);
            Assert.Equal("A", result);
        }

        [Fact]
        public void Handle_WithNoWord_ReturnEmptyString()
        {
            string logline = "Guess word ";
            string pattern = @"(\d+\s*[+*\/-]\s*\d+)";
            //Act
            var result = _handler.Handle(logline, pattern);
            //Assert
            Assert.IsType<string>(result);
            Assert.Equal("", result);
        }
    }
}
