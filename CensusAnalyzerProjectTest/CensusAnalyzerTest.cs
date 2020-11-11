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
        const string WRONG_INDIAN_CENSUS_CSV_HEADER_PATH = "C:/Users/Vishal/source/repos/CensusAnalyzer/CensusAnalyzerProjectTest/Utilities/IndiaStateCensusData - Copy - Copy.csv";
        const string INDIAN_STATE_CODE_CSV_PATH = "C:/Users/Vishal/source/repos/CensusAnalyzer/CensusAnalyzerProjectTest/utilities/IndiaStateCode.csv";
        const string WRONG_INDIA_STATE_CODE_CSV_DELIMITER_PATH = "C:/Users/Vishal/source/repos/CensusAnalyzer/CensusAnalyzerProjectTest/utilities/IndiaStateCode - Copy.csv";
        const string WRONG_INDIA_STATE_CODE_PATH = "C:/Users/Vishal/source/repos/CensusAnalyzer/CensusAnalyzerProjectTest/utilities/IndiaStateCode.txt";
        const string WRONG_INDIA_STATE_CODE_HEADER_PATH = "C:/Users/Vishal/source/repos/CensusAnalyzer/CensusAnalyzerProjectTest/utilities/WrongIndiaStateCode.csv";
        
        ICensusCSVLoader censusAnalyzerObj;
        ICensusCSVLoader filetype;
        Count countObj;
        ICensusCSVLoader delimiterObj;
        ICensusCSVLoader typeObj;
        ICensusCSVLoader headerObj;

        [SetUp]
        public void Setup()
        {
            censusAnalyzerObj = new CensusAnalyzer();
            filetype = new FileType(censusAnalyzerObj);
            typeObj = new CSVType(filetype);
            delimiterObj = new Delimiter(typeObj);
            headerObj = new Header(delimiterObj);
            countObj = new Count(headerObj);
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

        [Test]
        public void givenIndiaCensusCSV_WhenIncorrectHeader_ThrowsException()
        {
            try
            {
                countObj.GetCount(WRONG_INDIAN_CENSUS_CSV_HEADER_PATH, "IndianStateCensus");
            }
            catch (CensusAnalyzerExceptions e)
            {
                Assert.AreEqual(CensusAnalyzerExceptions.ExeptionType.INVALID_HEADER, e.ExceptionType);
            }
        }


        [Test]
        public void givenIndianStateCodeCSV_WhenCorrect_ReturnsNumberOfRecords()
        {

            int count = countObj.GetCount(INDIAN_STATE_CODE_CSV_PATH, "IndianStateCode");
            Assert.AreEqual(37, count);
        }



        [Test]
        public void givenIndianStateCodeCSV_WhenIncorrect_ThrowsException()
        {
            try
            {
                countObj.GetCount(WRONG_INDIA_STATE_CODE_PATH, "IndianStateCode");
            }
            catch (CensusAnalyzerExceptions e)
            {
                Assert.AreEqual(CensusAnalyzerExceptions.ExeptionType.INVALID_FILE, e.ExceptionType);
            }
        }

        [Test]
        public void givenCorrectIndianStateCodeCSV_WhenTypeIncorrect_ThrowsException()
        {
            try
            {
                countObj.GetCount(INDIAN_STATE_CODE_CSV_PATH, "wrong type");
            }
            catch (CensusAnalyzerExceptions e)
            {
                Assert.AreEqual(CensusAnalyzerExceptions.ExeptionType.INVALID_TYPE, e.ExceptionType);
            }
        }

        [Test]
        public void givenIndiaStateCodeCSV_WhenIncorrectDelimiter_ThrowsException()
        {
            try
            {
                delimiterObj.LoadData(WRONG_INDIA_STATE_CODE_CSV_DELIMITER_PATH, "IndianStateCensus");
            }
            catch (CensusAnalyzerExceptions e)
            {
                Assert.AreEqual(CensusAnalyzerExceptions.ExeptionType.INVALID_DELIMITER, e.ExceptionType);
            }
        }

        [Test]
        public void givenIndiaStateCodeCSV_WhenIncorrectHeader_ThrowsException()
        {
            try
            {
                countObj.GetCount(WRONG_INDIA_STATE_CODE_HEADER_PATH, "IndianStateCensus");
            }
            catch (CensusAnalyzerExceptions e)
            {
                Assert.AreEqual(CensusAnalyzerExceptions.ExeptionType.INVALID_HEADER, e.ExceptionType);
            }
        }


    }
}