
using ConsoleTableExt;
using PopulationDatabase.Services;
using PopulationDatabase.Services.Abstractions;
using PopulationServices;
using PopulationServices.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CountryPopulations
{
    class CountriyPopulations


    {
        static void Main(string[] args)
        {
            try
            {
                IDbPopulationService dbPopulationService = new DbPopulationService();
                var countryPopulationDict = dbPopulationService.GetCountryPopulationDict();

                IPopulationService countryPopulationService = new PopulationService();
                var countryPopulationData = countryPopulationService.GetCountryPopulations();

                foreach (var countryPopulationTuple in countryPopulationData)
                {
                    if (!countryPopulationDict.ContainsKey(countryPopulationTuple.Item1))
                    {
                        countryPopulationDict.Add(countryPopulationTuple.Item1, countryPopulationTuple.Item2);
                    }
                }

                var countryPopulations = countryPopulationDict
                    .OrderBy(pair => pair.Key)
                    .Select(pair => Tuple.Create(pair.Key, pair.Value)).ToList();

                PrittyPrint(countryPopulations);
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
        }

        static void PrittyPrint<T>(List<T> dataTable) where T : class
        {
            ConsoleTableBuilder
                .From<T>(dataTable)
                .WithColumn("Country Name", "Population")
                .WithHeaderTextAlignment(new Dictionary<int, TextAligntment>()
                {
                    { 0, TextAligntment.Center },
                    { 1, TextAligntment.Center }
                })
                .WithTextAlignment(new Dictionary<int, TextAligntment>()
                {
                    { 0, TextAligntment.Right },
                    { 1, TextAligntment.Left }
                })
                .WithFormat(ConsoleTableBuilderFormat.MarkDown)
                .ExportAndWriteLine(TableAligntment.Left);
        }
    }
}
