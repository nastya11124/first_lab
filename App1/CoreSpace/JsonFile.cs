
using System.Text.Json;

using App1.CoreSpace.Interfaces;
using App1.UserInterface;

namespace App1.CoreSpace
{
    public class JsonFile : IJsonFile
    {
        private string FILE_PATH;

        public JsonFile(string filePath)
        {
            FILE_PATH = filePath;
        }
        public async Task<Dictionary<string, List<string>>> LoadFromFile()
        {
            if (!File.Exists(FILE_PATH))
                return new Dictionary<string, List<string>>();

            var json = await File.ReadAllTextAsync(FILE_PATH);

            try
            {
                var dictionary = JsonSerializer.Deserialize<Dictionary<string, List<string>>>(json);

                if (dictionary == null)
                {
                    Exceptions e = new Exceptions("Не удалось десериализовать данные из файла.");
                    return new Dictionary<string, List<string>>();
                }

                return dictionary;
            }
            catch (JsonException)
            {
                Exceptions e = new Exceptions("Не удалось десериализовать данные из файла.");
                return new Dictionary<string, List<string>>();
            }
        }
        public async Task SaveToFile(Dictionary<string, List<string>> catalog)
        {
            try
            {
                var json = JsonSerializer.Serialize(catalog, new JsonSerializerOptions
                {
                    WriteIndented = true,
                    Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
                });

                await File.WriteAllTextAsync(FILE_PATH, json);

            }
            catch (DirectoryNotFoundException ex)
            {
                throw new DirectoryNotFoundException("Некорректный путь к файлу", ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при сохранении файла: {ex.Message}");
            }
        }
    }
}
