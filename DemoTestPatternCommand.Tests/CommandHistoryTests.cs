using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoTestPatternCommand.Tests
{
    public class CommandHistoryTests
    {
        [Fact]
        public void CommandHistoryTest()
        {
            //Arrange
            int x = 0;
            RelayCommandHistory commandHistory = new RelayCommandHistory();
            IRelayCommand command = new RelayCommand(() => x++, undo: () => x--);

            //Act
            command.Execute();

            //Assert
            Assert.Single(commandHistory.History);
            Assert.Equal(command, commandHistory.History.Last());
            Assert.Equal(1, x);
        }

        [Fact]
        public void CommandUndoTest()
        {
            //Arrange
            int x = 0;
            RelayCommandHistory commandHistory = new RelayCommandHistory();
            IRelayCommand command = new RelayCommand(() => x++, undo: () => x--);
            command.Execute();

            //Act
            commandHistory.Undo();

            //Assert
            Assert.Empty(commandHistory.History);
            Assert.Equal(0, x);
        }
    }
}
