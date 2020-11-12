using CensusAnalyzerProject;
using NUnit.Framework;
using CensusAnalyzerProject.Exceptions;
using CensusAnalyzerProject.Models;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using CensusAnalyzerProject.DTO;
using CensusAnalyzerProject.Enums;

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
        const string US_CENSUS_CSV_PATH = "C:/Users/Vishal/source/repos/CensusAnalyzer/CensusAnalyzerProjectTest/utilities/USCensusData.csv";
        const string WRONG_US_CENSUS_CSV_PATH = "C:/Users/Vishal/source/repos/CensusAnalyzer/CensusAnalyzerProjectTest/utilities/USCensusData.txt";
        const string WRONG_US_CENSUS_CSV_DELIMITER_PATH = "C:/Users/Vishal/source/repos/CensusAnalyzer/CensusAnalyzerProjectTest/utilities/WrongDelimiterUSCSV.csv";
        const string WRONG_US_CENSUS_CSV_HEADER_PATH = "C:/Users/Vishal/source/repos/CensusAnalyzer/CensusAnalyzerProjectTest/utilities/WrongHeaderUSCSV.csv";

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
            List<CensusDAO> sortedList = CSVObj.SortData(map, "state", "IndianStateCensusDTO", CustomEnums.sort.ASCENDING);
            Assert.AreEqual("Andhra Pradesh", sortedList[0].state);
            Assert.AreEqual("West Bengal", sortedList[sortedList.Count - 1].state);
        }


        [Test]
        public void givenIndianStateCodeCSV_WhenToSort_ReturnsSortedList()
        {
            Dictionary<string, List<CensusDAO>> map = CSVObj.LoadData(INDIAN_STATE_CODE_CSV_PATH, "IndianStateCodeDTO");
            List<CensusDAO> sortedList = CSVObj.SortData(map, "stateCode", "IndianStateCodeDTO", CustomEnums.sort.ASCENDING);
            Assert.AreEqual("AD", sortedList[0].stateCode);
            Assert.AreEqual("WB", sortedList[sortedList.Count - 1].stateCode);
        }
        


        [Test]
        public void givenIndiaStateCensus_AndIndiaStateCode_WhenTogether_LoadsSuccessfully()
        {
            CSVObj.LoadData(INDIAN_CENSUS_CSV_PATH, "IndianStateCensusDTO");
            Dictionary<string, List<CensusDAO>> map = CSVObj.LoadData(INDIAN_STATE_CODE_CSV_PATH, "IndianStateCodeDTO");
            Assert.IsTrue(map.ContainsKey("IndianStateCensusDTO"));
            Assert.IsTrue(map.ContainsKey("IndianStateCodeDTO"));
        }

        [Test]
        public void givenIndiaStateCensus_WhenToSortPopulation_ReturnsSortedPopulation()
        {
            Dictionary<string, List<CensusDAO>> map = CSVObj.LoadData(INDIAN_CENSUS_CSV_PATH, "IndianStateCensusDTO");
            List<CensusDAO> sortedList = CSVObj.SortData(map, "population", "IndianStateCensusDTO", CustomEnums.sort.DESCENDING);
            Assert.AreEqual(199812341, sortedList[0].population);
            Assert.AreEqual(607688, sortedList[sortedList.Count-1].population);
        }

        [Test]
        public void givenIndiaStateCensus_WhenToSortPopulationDensity_ReturnsSortedPopulationDensity()
        {
            Dictionary<string, List<CensusDAO>> map = CSVObj.LoadData(INDIAN_CENSUS_CSV_PATH, "IndianStateCensusDTO");
            List<CensusDAO> sortedList = CSVObj.SortData(map, "densityPerSquareKiloMeter", "IndianStateCensusDTO", CustomEnums.sort.DESCENDING);
            Assert.AreEqual(1102, sortedList[0].densityPerSquareKiloMeter);
            Assert.AreEqual(50, sortedList[sortedList.Count - 1].densityPerSquareKiloMeter);
        }

        [Test]
        public void givenIndiaStateCensus_WhenToSortArea_ReturnsSortedArea()
        {
            Dictionary<string, List<CensusDAO>> map = CSVObj.LoadData(INDIAN_CENSUS_CSV_PATH, "IndianStateCensusDTO");
            List<CensusDAO> sortedList = CSVObj.SortData(map, "areaInSquareKiloMeter", "IndianStateCensusDTO", CustomEnums.sort.DESCENDING);
            Assert.AreEqual(342239, sortedList[0].areaInSquareKiloMeter);
            Assert.AreEqual(3702, sortedList[sortedList.Count - 1].areaInSquareKiloMeter);
        }

        [Test]
        public void givenUSCensusCSV_WhenCorrect_ReturnsCount()
        {
            int count = CSVObj.GetCount(US_CENSUS_CSV_PATH, "USCensusDTO");
            Assert.AreEqual(51, count);
        }


        [Test]
        public void givenUSCensusCSV_WhenIncorrect_ThrowsException()
        {
            try
            {
                int count = CSVObj.GetCount(WRONG_US_CENSUS_CSV_PATH, "USCensusDTO");
            }
            catch (CensusAnalyzerExceptions e)
            {
                Assert.AreEqual(CensusAnalyzerExceptions.ExeptionType.INVALID_FILE, e.ExceptionType);
            }
        }

        [Test]
        public void givenCorrectUSCensusCSV_WhenTypeIncorrect_ThrowsException()
        {
            try
            {
                CSVObj.GetCount(US_CENSUS_CSV_PATH, "wrong type");
            }
            catch (CensusAnalyzerExceptions e)
            {
                Assert.AreEqual(CensusAnalyzerExceptions.ExeptionType.INVALID_TYPE, e.ExceptionType);
            }
        }


        [Test]
        public void givenUSCensusCSV_WhenIncorrectDelimiter_ThrowsException()
        {
            try
            {
                CSVObj.LoadData(WRONG_US_CENSUS_CSV_DELIMITER_PATH , "IndianStateCensusDTO");
            }
            catch (CensusAnalyzerExceptions e)
            {
                Assert.AreEqual(CensusAnalyzerExceptions.ExeptionType.INVALID_DELIMITER, e.ExceptionType);
            }
        }

    }
}