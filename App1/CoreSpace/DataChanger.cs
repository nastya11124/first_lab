using App1.UserInterface;

using App1.CoreSpace.Interfaces;

namespace App1.CoreSpace
{
    public class DataChanger : IDataChanger
    {
        private AbstractDataBase db;

        public DataChanger(AbstractDataBase db)
        {
            this.db = db;

        }
        public bool AddTrack(string author, string track)
        {
            Dictionary<string, List<string>> dictionaryFromData = this.db.GetCatalog();
            if (dictionaryFromData.ContainsKey(author))
            {
                if (dictionaryFromData[author].Contains(track))
                {
                    Exceptions e = new Exceptions("Введенный вами трек уже есть в каталоге");
                    return false;
                }
                else
                {
                    dictionaryFromData[author].Add(track);
                }
            }
            else
            {
                dictionaryFromData.Add(author, [track]);
            }
            return true;
        }

        public bool DeleteTrack(string author, string track)
        {
            Dictionary<string, List<string>> dictionaryFromData = this.db.GetCatalog();
            if (dictionaryFromData.ContainsKey(author))
            {
                if (dictionaryFromData[author].Contains(track))
                {
                    dictionaryFromData[author].Remove(track);
                    if(dictionaryFromData[author].Count() == 0)
                    {
                        dictionaryFromData.Remove(author);
                    }

                    return true;
                }
            }
            Exceptions e = new Exceptions("Введенного вами трека нет в каталоге");
            return false;
        }
    }
}

