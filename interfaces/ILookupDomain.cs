using System.Threading.Tasks;
using ISPDB_Lookup.Xml;

namespace ISPDB_Lookup.interfaces
{
    public interface ILookupDomain
    {
        Task<clientConfig> Find(string domain);
    }
}