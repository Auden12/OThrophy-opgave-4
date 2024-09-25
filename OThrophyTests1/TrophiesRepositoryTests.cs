using Microsoft.VisualStudio.TestTools.UnitTesting;
using OThrophy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OThrophy.Tests
{
    [TestClass]
    public class TrophiesRepositoryTest
    {
        private TrophiesRepository? _repository;

        [TestInitialize]
        public void Setup()
        {
            _repository = new TrophiesRepository();
        }

        [TestMethod]
        public void AddTorphy_ShouldAddTrophy()
        {

            var teacher = new Trophy { Competition = "last", Year = 1971 };

            var result = _repository.AddTrophy(teacher);

            Assert.AreEqual(1, result.Id);
            Assert.AreEqual(1, _repository.Get().Count);

        }

        [TestMethod]
        public void Get_ShouldReturnAllTrophy()
        {
            _repository.AddTrophy(new Trophy { Competition = "Last", Year = 1971 });
            _repository.AddTrophy(new Trophy { Competition = "2nd", Year = 2023 });

            var result = _repository.Get();

            Assert.AreEqual(2, result.Count);
        }

        [TestMethod]
        public void Get_WithMinYear_ShouldReturnFilteredTrophies()
        {
            _repository.AddTrophy(new Trophy { Competition = "Last", Year = 1971 });
            _repository.AddTrophy(new Trophy { Competition = "2nd", Year = 2023 });

            var result = _repository.Get(minYear: 1972);

            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("2nd", result[0].Competition);
        }

        [TestMethod]
        public void Get_WithComp_ShouldReturnFilteredTophies()
        {
            _repository.AddTrophy(new Trophy { Competition = "Last", Year = 1971 });
            _repository.AddTrophy(new Trophy { Competition = "2nd", Year = 2023 });

            var result = _repository.Get(comp: "last");

            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("last", result[0].Competition);
        }

        [TestMethod]
        public void Get_ById_ShouldReturnCorrectComp()
        {

            var trophy = _repository.AddTrophy(new Trophy { Competition = "Last", Year = 1971 });

            var result = _repository.Get(trophy.Id);

            Assert.IsNotNull(result);
            Assert.AreEqual("last", result.Competition);
        }
    }
}