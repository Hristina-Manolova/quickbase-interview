using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PopulationServices;
using PopulationServices.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PopulationTests
{
    [TestClass]
    public class PopulationServiceTests
    {
        #region Positive Tests
        [TestMethod]
        public void Call_GetCountryPopulations_NotEmpty()
        {
            IPopulationService populationService = new PopulationService();
            var countryPopulations = populationService.GetCountryPopulations();

            Assert.IsNotNull(countryPopulations);
            Assert.AreNotEqual(0, countryPopulations.Count());
        }

        [TestMethod]
        public void Call_GetCountryPopulations_GraterThanZero()
        {
            IPopulationService populationService = new PopulationService();
            var countryPopulations = populationService.GetCountryPopulations();

            Assert.IsNotNull(populationService.GetCountryPopulations());
            Assert.IsTrue(countryPopulations.Count() > 0);
        }

        [TestMethod]
        public void Mock_GetCountryPopulations_ReturnNull()
        {
            IEnumerable<Tuple<string, int>> mockedData = null;

            var mockedPopulationService = new Mock<IPopulationService>();
            mockedPopulationService.Setup(svc => svc.GetCountryPopulations()).Returns(mockedData);

            var countryPopulations = mockedPopulationService.Object.GetCountryPopulations();

            Assert.IsNull(countryPopulations);
            mockedPopulationService.Verify(svc => svc.GetCountryPopulations());
        }

        [TestMethod]
        public void Mock_GetCountryPopulations_NullRefernceException()
        {
            NullReferenceException mockedData = new NullReferenceException();

            var mockedPopulationService = new Mock<IPopulationService>();
            mockedPopulationService.Setup(svc => svc.GetCountryPopulations()).Throws(mockedData);

            try
            {
                var countryPopulations = mockedPopulationService.Object.GetCountryPopulations();
                Assert.Fail("Should throws NullReferenceException.");
            }
            catch (Exception ex)
            {
                Assert.AreEqual(typeof(NullReferenceException), ex.GetType());
            }

            mockedPopulationService.Verify(svc => svc.GetCountryPopulations());
        }
        #endregion Positive Tests


        #region Negative Tests

        [TestMethod]
        public void Call_GetCountryPopulations_EqualsToZero()
        {
            IPopulationService populationService = new PopulationService();
            var countryPopulations = populationService.GetCountryPopulations();

            Assert.IsNotNull(countryPopulations);
            Assert.IsFalse(countryPopulations.Count() == 0);
        }

        [TestMethod]
        public void Call_GetCountryPopulations_LessThanZero()
        {
            IPopulationService populationService = new PopulationService();
            var countryPopulations = populationService.GetCountryPopulations();

            Assert.IsNotNull(countryPopulations);
            Assert.IsFalse(countryPopulations.Count() < 0);
        }

        #endregion Negative Tests
    }
}
