using CensusAnalyzerProject;
using NUnit.Framework;
using CensusAnalyzerProject.Exceptions;
using System;
using System.IO;

namespace CensusAnalyzerProjectTest
{
    public class CensusAnalyzerTest
    {
        const string INDIAN_CENSUS_CSV_PATH = "C:/Users/Vishal/source/repos/CensusAnalyzer/CensusAnalyzerProjectTest/Utilities/IndiaStateCensusData.csv";
        const string WRONG_INDIAN_CENSUS_CSV_PATH = "C:/Users/Vishal/source/repos/CensusAnalyzer/CensusAnalyzerProjectTest/Utilities/IndiaStateCensusData.txt";
        CensusAnalyzer censusAnalyzerObj;
        [SetUp]
        public void Setup()
        {
            censusAnalyzerObj = new CensusAnalyzer();
        }

        [Test]
        public void givenIndianCensusCSV_WhenCorrect_ReturnsNumberOfRecords()
        {
            int count = censusAnalyzerObj.GetCount(INDIAN_CENSUS_CSV_PATH);
            Assert.AreEqual(29, count);
        }

        [Test]  
        public void givenIndianCensusCSV_WhenIncorrect_ReturnsException()
        {
            try
            {
                censusAnalyzerObj.VerifyCSV(WRONG_INDIAN_CENSUS_CSV_PATH);
            }
            catch (CensusAnalyzerExceptions e)
            {
                Assert.AreEqual(CensusAnalyzerExceptions.ExeptionType.INVALID_FILE, e.ExceptionType);
            }
        }
    }
}