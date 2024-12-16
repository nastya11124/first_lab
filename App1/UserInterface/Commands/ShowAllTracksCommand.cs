using App1.UserInterface.Commands.Interfaces;
using App1.CoreSpace;


namespace App1.UserInterface.Commands
{
    class ShowAllTracksCommand : Command
    {
        private Catalog _catalog;
        public ShowAllTracksCommand(Catalog catalog)
        {
            _catalog = catalog;
        }

        public void execute()
        {
            Dictionary<string, List<string>> tmp;

            tmp = this._catalog.ShowAllTracksOperation();
            if (tmp.Count == 0)
            {
                Console.WriteLine("Каталог пуст(\n");
            }
            else
            {
                Console.WriteLine("КАТАЛОГ:");
                foreach (var item in tmp)
                {
                    Console.WriteLine(item.Key + ":");
                    foreach (var track in item.Value)
                    {
                        Console.WriteLine("\t" + "-" + track);
                    }
                }
                Console.WriteLine();
            }
        }
    }
}