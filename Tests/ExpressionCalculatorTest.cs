using LogsReader;

namespace Tests
{
    public class ExpressionCalculatorTest
    {
        
        [Fact]
        public void Calculate_WithCorrectFormat_ReturnResult()
        {
            //Arrange
            var expression = "220 + 220";

            //Act
            var result = ExpressionCalculator.Calculate(expression, " ");
            //Assert
            Assert.IsType<double>(result);
            Assert.Equal(440, result);
        }
        [Fact]
        public void Calculate_WithWrongExpressionFormat_ReturnError()
        {
            //Arrange
            var expression = "220+220";

            //Act

            //Assert
            Assert.Throws<FormatException>(()=> ExpressionCalculator.Calculate(expression, " "));
            
        }
        [Fact]
        public void Calculate_WithWrongSepatator_ReturnError()
        {
            //Arrange
            var expression = "220 + 220";

            //Act
            
            //Assert
            Assert.Throws<FormatException> (() => ExpressionCalculator.Calculate(expression, "_"));
        }
        [Fact]
        public void Calculate_WithWrongExpression_ReturnError()
        {
            //Arrange
            var expression = "220 + 220 + AAA";

            //Act

            //Assert
            Assert.Throws<FormatException>(() => ExpressionCalculator.Calculate(expression, " "));
        }
        [Fact]
        public void Calculate_WithWrongExpressionOperators_ReturnError()
        {
            //Arrange
            var expression = "220 ++ 220 2";

            //Act

            //Assert
            Assert.Throws<InvalidOperationException>(() => ExpressionCalculator.Calculate(expression, " "));
        }

    }
}