
using App1.CoreSpace.Interfaces;

namespace App1.CoreSpace
{
    public class Catalog
    {
        private IDataChanger _dataChanger;
        private IDataSearcher _dataSearcher;

        public Catalog(IDataChanger DCh, IDataSearcher DSh)
        {
            this._dataChanger = DCh;
            this._dataSearcher = DSh;
        }
        public bool AddTrackOperation(string author, string name)
        {
            return this._dataChanger.AddTrack(author, name);
        }

        public Dictionary<string, List<string>> ShowAllTracksOperation()
        {
            return this._dataSearcher.Search();
        }

        public Dictionary<string, List<string>> FilterTrackOperation(string criterion, bool byAuthor)
        {
            return this._dataSearcher.Search(criterion, byAuthor);
        }
        public bool DeleteTrackOperation(string author, string name)
        {
            return this._dataChanger.DeleteTrack(author, name);
        }
    }
}
    
