using System.Collections.Generic;

namespace PopulationDatabase.Services.Abstractions
{
    public interface IDbPopulationService
    {
        IDictionary<string, int> GetCountryPopulationDict();
    }
}
