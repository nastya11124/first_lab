using App1.UserInterface.Commands.Interfaces;
using App1.CoreSpace;

namespace App1.UserInterface.Commands
{
    class DeleteTrack : Command
    {
        private Catalog _catalog;
        public DeleteTrack(Catalog catalog)
        {
            _catalog = catalog;
        }

        public void execute()
        {
            Console.Write("Введите исполнителя песни: ");
            string author = Console.ReadLine();
            Console.Write("Введите название песни: ");
            string name = Console.ReadLine();
            bool isDeleted = this._catalog.DeleteTrackOperation(author, name);

            if (isDeleted)
            {
                Console.WriteLine("трек успешно удален");
            }
        }
    }
}