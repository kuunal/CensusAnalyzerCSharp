using CensusAnalyzerProject;
using NUnit.Framework;
using CensusAnalyzerProject.Exceptions;
using CensusAnalyzerProject.Models;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

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
            
            int count = CSVObj.GetCount(INDIAN_CENSUS_CSV_PATH, "IndianStateCensusDTO");
            Assert.AreEqual(29, count);
        }

        [Test]  
        public void givenIndianCensusCSV_WhenIncorrect_ThrowsException()
        {
            try
            {
                int count = CSVObj.GetCount(WRONG_INDIAN_CENSUS_CSV_PATH, "IndianStateCensusDTO");
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
                CSVObj.LoadData(WRONG_INDIAN_CENSUS_CSV_DELIMITER_PATH, "IndianStateCensusDTO");
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
                CSVObj.GetCount(WRONG_INDIAN_CENSUS_CSV_HEADER_PATH, "IndianStateCensusDTO");
            }
            catch (CensusAnalyzerExceptions e)
            {
                Assert.AreEqual(CensusAnalyzerExceptions.ExeptionType.INVALID_HEADER, e.ExceptionType);
            }
        }


        [Test]
        public void givenIndianStateCodeCSV_WhenCorrect_ReturnsNumberOfRecords()
        {

            int count = CSVObj.GetCount(INDIAN_STATE_CODE_CSV_PATH, "IndianStateCodeDTO");
            Assert.AreEqual(37, count);
        }



        [Test]
        public void givenIndianStateCodeCSV_WhenIncorrect_ThrowsException()
        {
            try
            {
                CSVObj.GetCount(WRONG_INDIA_STATE_CODE_PATH, "IndianStateCodeDTO");
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
                CSVObj.LoadData(WRONG_INDIA_STATE_CODE_CSV_DELIMITER_PATH, "IndianStateCensusDTO");
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
                CSVObj.GetCount(WRONG_INDIA_STATE_CODE_HEADER_PATH, "IndianStateCensusDTO");
            }
            catch (CensusAnalyzerExceptions e)
            {
                Assert.AreEqual(CensusAnalyzerExceptions.ExeptionType.INVALID_HEADER, e.ExceptionType);
            }
        }

        
        [Test]
        public void givenIndianStateCensusCSV_WhenToSort_ReturnsSortedList()
        {
            Dictionary<string, List<CensusDAO>> map = CSVObj.LoadData(INDIAN_CENSUS_CSV_PATH, "IndianStateCensusDTO");
            List<CensusDAO> sortedList = CSVObj.SortData(map, "state", "IndianStateCensusDTO");
            Assert.AreEqual("Andhra Pradesh", sortedList[0].state);
            Assert.AreEqual("West Bengal", sortedList[sortedList.Count - 1].state);
        }


        [Test]
        public void givenIndianStateCodeCSV_WhenToSort_ReturnsSortedList()
        {
            Dictionary<string, List<CensusDAO>> map = CSVObj.LoadData(INDIAN_STATE_CODE_CSV_PATH, "IndianStateCodeDTO");
            List<CensusDAO> sortedList = CSVObj.SortData(map, "stateCode", "IndianStateCodeDTO");
            Assert.AreEqual("AD", sortedList[0].stateCode);
            Assert.AreEqual("WB", sortedList[sortedList.Count - 1].stateCode);
        }
        


        [Test]
        public void givenIndiaStateCensus_AndIndiaStateCode_WhenTogether_LoadsSuccessfully()
        {
            Dictionary<string, List<CensusDAO>> map1 = CSVObj.LoadData(INDIAN_CENSUS_CSV_PATH, "IndianStateCensusDTO");
            Dictionary<string, List<CensusDAO>> map = CSVObj.LoadData(INDIAN_STATE_CODE_CSV_PATH, "IndianStateCodeDTO");
            Assert.IsTrue(map1.ContainsKey("IndianStateCensusDTO"));
            Assert.IsTrue(map.ContainsKey("IndianStateCodeDTO"));
        }



    }
}