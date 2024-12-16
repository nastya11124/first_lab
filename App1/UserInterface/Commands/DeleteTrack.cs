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
            Console.Write("������� ����������� �����: ");
            string author = Console.ReadLine();
            Console.Write("������� �������� �����: ");
            string name = Console.ReadLine();
            bool isDeleted = this._catalog.DeleteTrackOperation(author, name);

            if (isDeleted)
            {
                Console.WriteLine("���� ������� ������");
            }
        }
    }
}