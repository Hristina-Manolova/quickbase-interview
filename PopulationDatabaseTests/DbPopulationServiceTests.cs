using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PopulationDatabase.Services;
using PopulationDatabase.Services.Abstractions;
using System;
using System.Collections.Generic;

namespace PopulationDatabaseTests
{
    [TestClass]
    public class DbPopulationServiceTests
    {
        #region Positive Tests
        [TestMethod]
        public void Call_GetCountryPopulationDict_NotEmpty()
        {
            IDbPopulationService dbPopulationService = new DbPopulationService();
            var countryPopulationDict = dbPopulationService.GetCountryPopulationDict();

            Assert.IsNotNull(countryPopulationDict);
            Assert.AreNotEqual(0, countryPopulationDict.Count);
        }

        [TestMethod]
        public void Call_GetCountryPopulationDict_GraterThanZero()
        {
            IDbPopulationService dbPopulationService = new DbPopulationService();
            var countryPopulationDict = dbPopulationService.GetCountryPopulationDict();

            Assert.IsNotNull(countryPopulationDict);
            Assert.IsTrue(countryPopulationDict.Count > 0);
        }

        [TestMethod]
        public void Mock_GetCountryPopulationDict_ReturnNull()
        {
            IDictionary<string, int> mockedData = null;

            var mockedDbPopulationService = new Mock<IDbPopulationService>();
            mockedDbPopulationService.Setup(svc => svc.GetCountryPopulationDict()).Returns(mockedData);

            var countryPopulationDict = mockedDbPopulationService.Object.GetCountryPopulationDict();

            Assert.IsNull(countryPopulationDict);
            mockedDbPopulationService.Verify(svc => svc.GetCountryPopulationDict());
        }

        [TestMethod]
        public void Mock_GetCountryPopulationDict_NullRefernceException()
        {
            NullReferenceException mockedData = new NullReferenceException();

            var mockedDbPopulationService = new Mock<IDbPopulationService>();
            mockedDbPopulationService.Setup(svc => svc.GetCountryPopulationDict()).Throws(mockedData);

            try
            {
                var countryPopulationDict = mockedDbPopulationService.Object.GetCountryPopulationDict();
                Assert.Fail("Should throws NullReferenceException.");
            }
            catch (Exception ex)
            {
                Assert.AreEqual(typeof(NullReferenceException), ex.GetType());
            }
            
            mockedDbPopulationService.Verify(svc => svc.GetCountryPopulationDict());
        }

        #endregion Positive Tests

        #region Negative Tests

        [TestMethod]
        public void Call_GetCountryPopulationDict_EqualsToZero()
        {
            IDbPopulationService populationService = new DbPopulationService();
            var countryPopulations = populationService.GetCountryPopulationDict();

            Assert.IsNotNull(countryPopulations);
            Assert.IsFalse(countryPopulations.Count == 0);
        }

        [TestMethod]
        public void Call_GetCountryPopulations_LessThanZero()
        {
            IDbPopulationService populationService = new DbPopulationService();
            var countryPopulations = populationService.GetCountryPopulationDict();

            Assert.IsNotNull(countryPopulations);
            Assert.IsFalse(countryPopulations.Count < 0);
        }

        #endregion Negative Tests
    }
}
