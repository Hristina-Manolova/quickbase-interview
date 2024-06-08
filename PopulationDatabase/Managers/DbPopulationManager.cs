using PopulationDatabase.Managers.Abstractions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using System.IO;

namespace PopulationDatabase.Managers
{
    internal class DbPopulationManager : IDbManager, IDbPopulationManager
    {
        public DbConnection GetOpenConnection()
        {
            DbConnection dbConnection = null;

            try
            {
                var connection = new SQLiteConnection($@"Data Source={Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName}\PopulationDatabase\Repository\citystatecountry.db;Version=3;FailIfMissing=true;");
                dbConnection = connection.OpenAndReturn();
            }
            catch (SQLiteException ex)
            {
                // Simulate logging of the error
                Console.WriteLine(ex.Message);
            }

            return dbConnection;
        }

        public IDictionary<string, int> GetCountryPopulations()
        {
            IDictionary<string, int> countryPopulationDict = null;
            try
            {
                using (var connection = this.GetOpenConnection())
                {
                    var cmdSelect = connection.CreateCommand();
                    cmdSelect.CommandText = @"SELECT CountryName, SUM(Population) AS 'Population'
                        FROM Country c
                        JOIN State as s
	                        ON c.CountryId = s.CountryId
                        JOIN City ct
	                        ON s.StateId = ct.StateId
                        GROUP BY 1;";

                    cmdSelect.CommandType = CommandType.Text;
                    using (var reader = cmdSelect.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            countryPopulationDict = new Dictionary<string, int>();
                        }
                        while (reader.Read())
                        {
                            string countryName = reader.GetString(0);
                            int population = Convert.ToInt32(reader.GetDecimal(1));
                            countryPopulationDict.Add(countryName, population);
                        }
                    }
                }
            }
            catch (SQLiteException sqliteEx)
            {
                // Simulate logging of the error
                Console.WriteLine(sqliteEx.Message);
            }
            catch (ArgumentNullException argEx)
            {
                // Simulate logging of the error
                Console.WriteLine(argEx.Message);
            }
            catch (InvalidCastException castEx)
            {
                // Simulate logging of the error
                Console.WriteLine(castEx.Message);
            }

            return countryPopulationDict;
        }
    }
}
