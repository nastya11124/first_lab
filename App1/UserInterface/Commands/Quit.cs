using App1.UserInterface.Commands.Interfaces;

namespace App1.UserInterface.Commands
{
    class Quit : Command
    {
        public void execute()
        {
            Console.WriteLine("Сеанс работы завершен");
            Console.ReadKey();
            Environment.Exit(0);
        }
    }
}