using System.Collections.Generic;

namespace PopulationDatabase.Managers.Abstractions
{
    internal interface IDbPopulationManager
    {
        IDictionary<string, int> GetCountryPopulations();
    }
}
