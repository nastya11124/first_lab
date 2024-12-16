using App1.UserInterface.Commands.Interfaces;
using App1.CoreSpace;

namespace App1.UserInterface
{
    public class Invoker
    {
        private Dictionary<string, Command> commands;

        public Invoker()
        {
            commands = new Dictionary<string, Command>();
        }

        public void SetCommand(string CommandName, Command command)
        {
            this.commands.Add(CommandName, command);
        }
        public void ExecuteCommand(string CommandName)
        {
            if (this.commands.ContainsKey(CommandName))
            {
                this.commands[CommandName].execute();
            }
            else
            {
                Exceptions e = new Exceptions("Такой команды нет в списке");

            }


        }
    }
}

