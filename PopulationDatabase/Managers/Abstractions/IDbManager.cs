using System.Data.Common;

namespace PopulationDatabase.Managers.Abstractions
{
    internal interface IDbManager
    {
        DbConnection GetOpenConnection();
    }
}
