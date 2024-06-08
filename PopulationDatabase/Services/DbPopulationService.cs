using PopulationDatabase.Managers;
using PopulationDatabase.Managers.Abstractions;
using PopulationDatabase.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace PopulationDatabase.Services
{
    public class DbPopulationService : IDbPopulationService
    {
        public IDictionary<string, int> GetCountryPopulationDict()
        {
            IDictionary<string, int> countryPopulationDict = null;
            try
            {
                IDbPopulationManager populationManager = new DbPopulationManager();
                countryPopulationDict = populationManager.GetCountryPopulations();
            }
            catch (NullReferenceException refEx)
            {
                // Simulate logging of the error
                Console.WriteLine(refEx.Message);
            }
            catch (Exception ex)
            {
                // Simulate logging of the error
                Console.WriteLine(ex.Message);
            }

            return countryPopulationDict;
        }
    }
}
