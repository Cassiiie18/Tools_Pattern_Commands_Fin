using Tools.Pattern.Commands;

namespace DemoTestPatternCommand.Tests
{
    public class RelayCommandTests
    {
        [Fact]
        public void TestRelayCommand()
        {
            //Arrange
            int x = 0;
            IRelayCommand command = new RelayCommand(() => x++);

            //Act
            command.Execute();

            //Assert
            Assert.Equal(1, x);
        }

        [Fact]
        public void TestRelayCommandWithValidCondition()
        {
            //Arrange
            int x = 0;
            IRelayCommand command = new RelayCommand(() => x++, () => x == 0);

            //Act
            command.Execute();

            //Assert
            Assert.Equal(1, x);
        }

        [Fact]
        public void TestRelayCommandWithInvalidCondition()
        {
            //Arrange
            int x = 0;
            IRelayCommand command = new RelayCommand(() => x++, () => x == 1);

            //Act
            command.Execute();

            //Assert
            Assert.Equal(0, x);
        }
    }
}