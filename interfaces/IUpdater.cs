using System.Threading.Tasks;

namespace ISPDB_Lookup.interfaces
{
    public interface IUpdater
    {
        void SetLink(string link);
        Task DownloadDatabase();
    }
}