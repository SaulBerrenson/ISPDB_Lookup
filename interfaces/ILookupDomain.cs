using ISPDB_Lookup.Xml;

namespace ISPDB_Lookup.interfaces
{
    public interface ILookupDomain
    {
        clientConfig Find(string domain);
    }
}