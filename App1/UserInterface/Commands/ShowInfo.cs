using App1.UserInterface.Commands.Interfaces;

namespace App1.UserInterface.Commands
{
    class ShowInfo : Command
    {
        public void execute()
        {
            Console.WriteLine("Доступные для вас команды:\n'каталог' - позволит увидеть все треки в каталоге;\n" +
                "'найти' - позволит выполнить поиск трека по критерию автор/название;\n" +
                "'добавить' - позволит добавить определенный трек в каталог;\n" +
                "'удалить' - позволит удалить определенный трек из каталога;\n" +
                "'выйти' - закончит работу программы;\n");
        }
    }
}