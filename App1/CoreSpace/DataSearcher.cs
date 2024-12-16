
using App1.CoreSpace.Interfaces;

namespace App1.CoreSpace
{
    public class DataSearcher : IDataSearcher
    {
        private AbstractDataBase db;

        public DataSearcher(AbstractDataBase db)
        {
            this.db = db;
        }

        public Dictionary<string, List<string>> Search(string criterion, bool byAuthor)
        {
            Dictionary<string, List<string>> found = new Dictionary<string, List<string>>();

            if (byAuthor)
            {
                foreach (var key in this.db.GetCatalog().Keys)
                {
                    if (key.Contains(criterion))
                    {
                        found[key] = this.db.GetCatalog()[key];
                    }
                }
            }
            else
            {
                foreach (var item in this.db.GetCatalog())
                {
                    foreach (var track in item.Value)
                    {
                        if (track.Contains(criterion))
                        {
                            if (found.ContainsKey(item.Key))
                            {
                                found[item.Key].Add(track);
                            }
                            else
                            {
                                found[item.Key] = new List<string> { track };
                            }
                        }
                    }
                }
            }

            return found;
        }

        public Dictionary<string, List<string>> Search()
        {
            return this.db.GetCatalog();
        }
    }
}

