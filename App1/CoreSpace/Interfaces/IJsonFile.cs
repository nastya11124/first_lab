namespace App1.CoreSpace.Interfaces
{
    public interface IJsonFile
    {
        Task<Dictionary<string, List<string>>> LoadFromFile();
        Task SaveToFile(Dictionary<string, List<string>> data);
    }

}