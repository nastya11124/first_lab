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
			Console.WriteLine("�� ������ �������� ������ ���������� �����: ����������� ��� ����?");
			string criterion = Console.ReadLine();
			if (criterion != "�����������" && criterion != "����")
			{
				Exceptions e = new Exceptions("������ �������� ��������");
				return;
			}
			Console.WriteLine("������� ��������");
			string name = Console.ReadLine();
			Dictionary<string, List<string>> tmp;

			if (criterion == "�����������")
			{
				tmp = this._catalog.FilterTrackOperation(name, true);
			}
			else
			{
				tmp = this._catalog.FilterTrackOperation(name, false);
			}

			if (tmp.Count == 0)
			{
				Console.WriteLine("���������� �� �������(\n");
			}
			else
			{
				Console.WriteLine("����������:");
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