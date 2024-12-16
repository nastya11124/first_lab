
using App1.CoreSpace;
using App1.CoreSpace.Interfaces;
using App1.UserInterface;

namespace App1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            const string FILE_PATH = @"D:\учебка\прога\first_lab\App1\music_catalog.json";
            AbstractDataBase data = new DataBase();
            IJsonFile file = new JsonFile(FILE_PATH);

            Сontainer app = new Сontainer(data, file);
            await app.Run();
        }
    }
}