using System;
using System.Collections.Generic;

namespace PopulationServices.Abstractions
{
    public interface IPopulationService
    {
        IEnumerable<Tuple<string, int>> GetCountryPopulations();
    }
}
