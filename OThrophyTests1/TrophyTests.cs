using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass()]
    public class TrophyTests
    {
        [TestMethod()]
        public void ValidateYearTest()
        {
            Trophy YearTooHigh = new Trophy()
            {
                Year = 2025
            };

            Trophy YearTooLow = new Trophy()
            {
                Year = 1969
            };
            Trophy YearWithininRange = new Trophy()
            {
                Year = 2023
            };


            Assert.ThrowsException<ArgumentOutOfRangeException>(
                () => YearTooHigh.ValidateYear());
            Assert.ThrowsException<ArgumentOutOfRangeException>(
                () => YearTooLow.ValidateYear());


        }
        [TestMethod()]
        public void ValidateCompetition()

        {
            Trophy TrophyWithCompetition = new Trophy()
            {
                Competition = "1st.",
            };
            Trophy CompetitionNull = new Trophy()
            {
            };
            Trophy CompetitionZeroLetters = new Trophy()
            {
                Competition = ""
            };

            Assert.ThrowsException<ArgumentNullException>(
                () => CompetitionNull.ValidateCompetition());

            Assert.ThrowsException<ArgumentOutOfRangeException>(
                () => CompetitionZeroLetters.ValidateCompetition());

            TrophyWithCompetition.ValidateCompetition();




        }
        [TestMethod()]
        public void ToStringTrophy()
        {
            Trophy StudentToString = new Trophy()
            {
                Id = 1,
                Competition = "1st",
                Year = 2023
            };
            StudentToString.ToString();
        }
    }
}