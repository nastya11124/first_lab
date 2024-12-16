

namespace App1.CoreSpace.Interfaces
{
    public interface IDataSearcher
    {
        public Dictionary<string, List<string>> Search(string criterion, bool byAuthor);
        public Dictionary<string, List<string>> Search();
    }
}