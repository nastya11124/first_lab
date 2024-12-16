using App1.UserInterface.Commands.Interfaces;
using App1.CoreSpace;

namespace App1.UserInterface.Commands
{
	class FindTrackCommand : Command
	{
		private Catalog _catalog;

		public FindTrackCommand(Catalog catalog)
		{
			_catalog = catalog;
		}

		public void execute()
		{
			Console.WriteLine("По какому критерию хотите произвести поиск: исполнитель или трек?");
			string criterion = Console.ReadLine();
			if (criterion != "исполнитель" && criterion != "трек")
			{
				Exceptions e = new Exceptions("Введен неверный критерий");
				return;
			}
			Console.WriteLine("Введите значение");
			string name = Console.ReadLine();
			Dictionary<string, List<string>> tmp;

			if (criterion == "исполнитель")
			{
				tmp = this._catalog.FilterTrackOperation(name, true);
			}
			else
			{
				tmp = this._catalog.FilterTrackOperation(name, false);
			}

			if (tmp.Count == 0)
			{
				Console.WriteLine("Совпадений не найдено(\n");
			}
			else
			{
				Console.WriteLine("СОВПАДЕНИЯ:");
				foreach (var item in tmp)
				{
					Console.Write(item.Key + ":");
					foreach (var track in item.Value)
					{
						Console.WriteLine("\t"+ "-"+track);
					}
				}
			}

		}
	}
}