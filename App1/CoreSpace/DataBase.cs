
using App1.CoreSpace.Interfaces;

namespace App1.CoreSpace
{
    class DataBase : AbstractDataBase
    {
        private Dictionary<string, List<string>> catalog;

        public DataBase()
        {
            catalog = new Dictionary<string, List<string>>();
        }
        public Dictionary<string, List<string>> GetCatalog()
        {
            return catalog;
        }
        public void SetCatalog(Dictionary<string, List<string>> startCatalog)
        {
            catalog = startCatalog;
        }
    }
}




