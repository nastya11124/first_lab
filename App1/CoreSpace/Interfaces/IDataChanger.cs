
namespace App1.CoreSpace.Interfaces
{
    public interface IDataChanger
    {
        public bool AddTrack(string author, string name);
        public bool DeleteTrack(string author, string name);
    }
}