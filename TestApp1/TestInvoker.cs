using App1.UserInterface.Commands.Interfaces;
using App1.UserInterface;
using Moq;
using System.Reflection;

namespace TestApp1
{
    public class InvokerTests
    {
        private Invoker invoker;
        private Mock<Command> mockCommand;

        public InvokerTests()
        {
            invoker = new Invoker();
            mockCommand = new Mock<Command>();
        }

        [Fact]
        public void SetCommand_ShouldAddCommandToDictionary()
        {
            // Arrange
            string commandName = "TestCommand";

            // Act
            invoker.SetCommand(commandName, mockCommand.Object);

            // Assert
            var commandsField = typeof(Invoker).GetField("commands", BindingFlags.NonPublic | BindingFlags.Instance);
            var commands = commandsField.GetValue(invoker) as Dictionary<string, Command>;

            Assert.True(commands.ContainsKey(commandName));
            Assert.Equal(mockCommand.Object, commands[commandName]);
        }

        [Fact]
        public void ExecuteCommand_ExistingCommand_ShouldExecuteCommand()
        {
            // Arrange
            string commandName = "TestCommand";
            invoker.SetCommand(commandName, mockCommand.Object);

            // Act
            invoker.ExecuteCommand(commandName);

            // Assert
            mockCommand.Verify(command => command.execute(), Times.Once);
        }
    }
}
