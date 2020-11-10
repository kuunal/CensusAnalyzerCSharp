using CensusAnalyzerProject;
using NUnit.Framework;
using CensusAnalyzerProject.Exceptions;
using CensusAnalyzerProject.Models;
using System;
using System.IO;

namespace CensusAnalyzerProjectTest
{
    public class CensusAnalyzerTest
    {   
        const string INDIAN_CENSUS_CSV_PATH = "C:/Users/Vishal/source/repos/CensusAnalyzer/CensusAnalyzerProjectTest/Utilities/IndiaStateCensusData.csv";
        const string WRONG_INDIAN_CENSUS_CSV_PATH = "C:/Users/Vishal/source/repos/CensusAnalyzer/CensusAnalyzerProjectTest/Utilities/IndiaStateCensusData.txt";
        const string WRONG_INDIAN_CENSUS_CSV_DELIMITER_PATH = "C:/Users/Vishal/source/repos/CensusAnalyzer/CensusAnalyzerProjectTest/Utilities/IndiaStateCensusData - Copy.csv";
        ICensusCSVLoader censusAnalyzerObj;
        Count countObj;
        ICensusCSVLoader delimiterObj;
        ICensusCSVLoader typeObj;

        [SetUp]
        public void Setup()
        {
            censusAnalyzerObj = new CensusAnalyzer();
            typeObj = new Delimiter(censusAnalyzerObj);
            delimiterObj = new Delimiter(typeObj);
            countObj = new Count(delimiterObj);
        }

        [Test]
        public void givenIndianCensusCSV_WhenCorrect_ReturnsNumberOfRecords()
        {
            
            int count = countObj.GetCount(INDIAN_CENSUS_CSV_PATH, "IndianStateCensus");
            Assert.AreEqual(29, count);
        }

        [Test]  
        public void givenIndianCensusCSV_WhenIncorrect_ThrowsException()
        {
            try
            {
                countObj.GetCount(WRONG_INDIAN_CENSUS_CSV_PATH, "IndianStateCensus");
            }
            catch (CensusAnalyzerExceptions e)
            {
                Assert.AreEqual(CensusAnalyzerExceptions.ExeptionType.INVALID_FILE, e.ExceptionType);
            }
        }

        [Test]
        public void givenCorrectIndianCensusCSV_WhenTypeIncorrect_ThrowsException()
        {
            try
            {
                countObj.GetCount(INDIAN_CENSUS_CSV_PATH, "wrong type");
            }catch(CensusAnalyzerExceptions e)
            {
                Assert.AreEqual(CensusAnalyzerExceptions.ExeptionType.INVALID_TYPE ,e.ExceptionType);
            }
        }

        [Test]
        public void givenIndiaCensusCSV_WhenIncorrectDelimiter_ThrowsException()
        {
            try { 
                delimiterObj.LoadData(WRONG_INDIAN_CENSUS_CSV_DELIMITER_PATH, "IndianStateCensus");
            }catch(CensusAnalyzerExceptions e)
            {
                Assert.AreEqual(CensusAnalyzerExceptions.ExeptionType.INVALID_DELIMITER, e.ExceptionType);
            }
        }
    }
}