
using Xunit;

namespace CursoOnline.DomainTest
{
    public class MyFirstTest
    {
        [Fact(DisplayName = "VariablesMustBeEquals")]
        public void VariablesMustBeEquals()
        {
            ///AAA

            //Arrange            
            int number1;
            int number2;

            //Act
            number2 = 1;
            number1 = number2;

            //Assert
            Assert.Equal(number1, number2);
        }
    }
}
