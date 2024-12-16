using App1.CoreSpace;
using App1.CoreSpace.Interfaces;
using App1.UserInterface.Commands;

namespace App1.UserInterface;

public class Сontainer
{
    private AbstractDataBase _dataCatalog;
    private IJsonFile _jsonDataSaver;
    public Сontainer(AbstractDataBase data, IJsonFile dataSaver)
    {
        _dataCatalog = data;
        _jsonDataSaver = dataSaver;
    }

    private async Task LoadDataCatalog()
    {
        var dataFromFile = await _jsonDataSaver.LoadFromFile();
        _dataCatalog.SetCatalog(dataFromFile);
    }

    private async Task SaveDataCatalog()
    {
        var newData = _dataCatalog.GetCatalog();
        await _jsonDataSaver.SaveToFile(newData);
    }

    public async Task Run()
    {
        await this.LoadDataCatalog();

        IDataChanger DCh = new DataChanger(_dataCatalog);
        IDataSearcher DSh = new DataSearcher(_dataCatalog);
        Invoker invoker = new Invoker();
        Catalog catalog = new Catalog(DCh, DSh);

        invoker.SetCommand("каталог", new ShowAllTracksCommand(catalog));
        invoker.SetCommand("удалить", new DeleteTrack(catalog));
        invoker.SetCommand("добавить", new AddTrackCommand(catalog));
        invoker.SetCommand("найти", new FindTrackCommand(catalog));
        invoker.SetCommand("выйти", new Quit());
        invoker.SetCommand("справка", new ShowInfo());


        invoker.ExecuteCommand("справка");
        string UserCommand;
        while (true)
        {
            Console.WriteLine("Введите комманду:\n");
            UserCommand = Console.ReadLine();
            Console.WriteLine();
            invoker.ExecuteCommand(UserCommand);
            await SaveDataCatalog();
        }
    }

}
