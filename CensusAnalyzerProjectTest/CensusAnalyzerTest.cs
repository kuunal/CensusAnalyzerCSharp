using CensusAnalyzerProject;
using NUnit.Framework;
using CensusAnalyzerProject.Exceptions;
using CensusAnalyzerProject.Models;
using System;
using System.IO;
using System.Collections;

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

        Factory factory = new Factory();
        Services CSVObj;


        [SetUp]
        public void Setup()
        {
            CSVObj = factory.GetCSVLoader();
        }

        [Test]
        public void givenIndianCensusCSV_WhenCorrect_ReturnsNumberOfRecords()
        {
            
            int count = CSVObj.GetCount(INDIAN_CENSUS_CSV_PATH, "IndianStateCensus");
            Assert.AreEqual(29, count);
        }

        [Test]  
        public void givenIndianCensusCSV_WhenIncorrect_ThrowsException()
        {
            try
            {
                int count = CSVObj.GetCount(WRONG_INDIAN_CENSUS_CSV_PATH, "IndianStateCensus");
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
                CSVObj.GetCount(INDIAN_CENSUS_CSV_PATH, "wrong type");
            }catch(CensusAnalyzerExceptions e)
            {
                Assert.AreEqual(CensusAnalyzerExceptions.ExeptionType.INVALID_TYPE ,e.ExceptionType);
            }
        }

        [Test]
        public void givenIndiaCensusCSV_WhenIncorrectDelimiter_ThrowsException()
        {
            try { 
                CSVObj.LoadData(WRONG_INDIAN_CENSUS_CSV_DELIMITER_PATH, "IndianStateCensus");
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
                CSVObj.GetCount(WRONG_INDIAN_CENSUS_CSV_HEADER_PATH, "IndianStateCensus");
            }
            catch (CensusAnalyzerExceptions e)
            {
                Assert.AreEqual(CensusAnalyzerExceptions.ExeptionType.INVALID_HEADER, e.ExceptionType);
            }
        }


        [Test]
        public void givenIndianStateCodeCSV_WhenCorrect_ReturnsNumberOfRecords()
        {

            int count = CSVObj.GetCount(INDIAN_STATE_CODE_CSV_PATH, "IndianStateCode");
            Assert.AreEqual(37, count);
        }



        [Test]
        public void givenIndianStateCodeCSV_WhenIncorrect_ThrowsException()
        {
            try
            {
                CSVObj.GetCount(WRONG_INDIA_STATE_CODE_PATH, "IndianStateCode");
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
                CSVObj.GetCount(INDIAN_STATE_CODE_CSV_PATH, "wrong type");
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
                CSVObj.LoadData(WRONG_INDIA_STATE_CODE_CSV_DELIMITER_PATH, "IndianStateCensus");
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
                CSVObj.GetCount(WRONG_INDIA_STATE_CODE_HEADER_PATH, "IndianStateCensus");
            }
            catch (CensusAnalyzerExceptions e)
            {
                Assert.AreEqual(CensusAnalyzerExceptions.ExeptionType.INVALID_HEADER, e.ExceptionType);
            }
        }

        [Test]
        public void givenIndianStateCensusCSV_WhenToSort_ReturnsSortedList()
        {
            ArrayList list = CSVObj.LoadData(INDIAN_CENSUS_CSV_PATH, "IndianStateCensus");
            ArrayList sortedList = CSVObj.SortData(list, "state");
            Assert.AreEqual(sortedList[0].ToString(), "Andhra Pradesh,49386799,162968,303");
          //  Assert.AreEqual(sortedList[sortedList.Count-1].ToString(), "West Bengal,91347736,88752,1029");
        }


        [Test]
        public void givenIndianStateCodeCSV_WhenToSort_ReturnsSortedList()
        {
            ArrayList list = CSVObj.LoadData(INDIAN_STATE_CODE_CSV_PATH, "IndianStateCode");
            ArrayList sortedList = CSVObj.SortData(list, "stateCode");
            Assert.AreEqual("3,Andhra Pradesh New,37,AD", sortedList[0].ToString());
            Assert.AreEqual("37,West Bengal,19,WB", sortedList[sortedList.Count - 1].ToString());
        }


    }
}