using App1.UserInterface.Commands.Interfaces;
using App1.CoreSpace;

namespace App1.UserInterface.Commands
{
	class AddTrackCommand : Command
	{
		private Catalog _catalog;
		public AddTrackCommand(Catalog catalog)
		{
			this._catalog = catalog;
		}
		public void execute()
		{
			Console.Write("Введите исполнителя песни: ");
			string author = Console.ReadLine();
			Console.Write("Введите название песни: ");
			string name = Console.ReadLine();
			bool isAdded = this._catalog.AddTrackOperation(author, name);

			if (isAdded)
			{
				Console.WriteLine("трек успешно добавлен");

            }
		}
	}
}