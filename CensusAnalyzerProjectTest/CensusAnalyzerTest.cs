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
            CSVObj = new Services();
        }
        
        [Test]
        public void givenIndianCensusCSVToAnalyze_WhenCorrect_ShouldReturnNumberOfRecords()
        {
            
            int count = CSVObj.GetCount(INDIAN_CENSUS_CSV_PATH,CustomEnums.TYPE.INDIASTATECENSUS);
            Assert.AreEqual(29, count);
        }

        [Test]  
        public void givenIndianCensusCSVToAnalyze_WhenIncorrect_ShouldThrowInvalidFileException()
        {
            try
            {
                int count = CSVObj.GetCount(WRONG_INDIAN_CENSUS_CSV_PATH,CustomEnums.TYPE.INDIASTATECENSUS);
            }
            catch (CensusAnalyzerExceptions e)
            {
                Assert.AreEqual(CensusAnalyzerExceptions.ExeptionType.INVALID_FILE, e.ExceptionType);
            }
        }

        [Test]
        public void givenCorrectIndianCensusCSVToAnalyze_WhenTypeIncorrect_ShouldThrowInvalidTypeException()
        {
            try
            {
                CSVObj.GetCount(INDIAN_CENSUS_CSV_PATH, CustomEnums.TYPE.WRONGTYPE);
            }catch(CensusAnalyzerExceptions e)
            {
                Assert.AreEqual(CensusAnalyzerExceptions.ExeptionType.INVALID_TYPE ,e.ExceptionType);
            }
        }

        [Test]
        public void givenIndiaCensusCSVToAnalyze_WhenIncorrectDelimiter_ShouldThrowException()
        {
            try { 
                CSVObj.LoadData(WRONG_INDIAN_CENSUS_CSV_DELIMITER_PATH,CustomEnums.TYPE.INDIASTATECENSUS);
            }catch(CensusAnalyzerExceptions e)
            {
                Assert.AreEqual(CensusAnalyzerExceptions.ExeptionType.INVALID_DELIMITER, e.ExceptionType);
            }
        }

        [Test]
        public void givenIndiaCensusCSVToAnalyze_WhenIncorrectHeader_ShouldThrowInvalidHeaderException()
        {
            try
            {
                CSVObj.GetCount(WRONG_INDIAN_CENSUS_CSV_HEADER_PATH,CustomEnums.TYPE.INDIASTATECENSUS);
            }
            catch (CensusAnalyzerExceptions e)
            {
                Assert.AreEqual(CensusAnalyzerExceptions.ExeptionType.INVALID_HEADER, e.ExceptionType);
            }
        }


        [Test]
        public void givenIndianStateCodeCSVToAnalyze_WhenCorrect_ShouldReturnNumberOfRecords()
        {

            int count = CSVObj.GetCount(INDIAN_STATE_CODE_CSV_PATH,CustomEnums.TYPE.INDIASTATECODE);
            Assert.AreEqual(37, count);
        }



        [Test]
        public void givenIndianStateCodeCSVToAnalyze_WhenIncorrect_ShouldThrowInvalidFileException()
        {
            try
            {
                CSVObj.GetCount(WRONG_INDIA_STATE_CODE_PATH,CustomEnums.TYPE.INDIASTATECODE);
            }
            catch (CensusAnalyzerExceptions e)
            {
                Assert.AreEqual(CensusAnalyzerExceptions.ExeptionType.INVALID_FILE, e.ExceptionType);
            }
        }

        [Test]
        public void givenCorrectIndianStateCodeCSVToAnalyze_WhenTypeIncorrect_ShouldThrowInvalidTypeException()
        {
            try
            {
                CSVObj.GetCount(INDIAN_STATE_CODE_CSV_PATH, CustomEnums.TYPE.WRONGTYPE);
            }
            catch (CensusAnalyzerExceptions e)
            {
                Assert.AreEqual(CensusAnalyzerExceptions.ExeptionType.INVALID_TYPE, e.ExceptionType);
            }
        }

        [Test]
        public void givenIndiaStateCodeCSVToAnalyze_WhenIncorrectDelimiter_ShouldThrowException()
        {
            try
            {
                CSVObj.LoadData(WRONG_INDIA_STATE_CODE_CSV_DELIMITER_PATH,CustomEnums.TYPE.INDIASTATECENSUS);
            }
            catch (CensusAnalyzerExceptions e)
            {
                Assert.AreEqual(CensusAnalyzerExceptions.ExeptionType.INVALID_DELIMITER, e.ExceptionType);
            }
        }

        [Test]
        public void givenIndiaStateCodeCSVToAnalyze_WhenIncorrectHeader_ShouldThrowInvalidHeaderException()
        {
            try
            {
                CSVObj.GetCount(WRONG_INDIA_STATE_CODE_HEADER_PATH,CustomEnums.TYPE.INDIASTATECENSUS);
            }
            catch (CensusAnalyzerExceptions e)
            {
                Assert.AreEqual(CensusAnalyzerExceptions.ExeptionType.INVALID_HEADER, e.ExceptionType);
            }
        }

        
        [Test]
        public void givenIndianStateCensusCSVToAnalyze_WhenToSort_ShouldReturnSortedList()
        {
            CSVObj.LoadData(INDIAN_CENSUS_CSV_PATH,CustomEnums.TYPE.INDIASTATECENSUS);
            IndianStateCensusDTO[] sortedList = CSVObj.SortData<IndianStateCensusDTO>( CustomEnums.FIELDS.STATE, new CustomEnums.TYPE[] {CustomEnums.TYPE.INDIASTATECENSUS }, CustomEnums.sort.ASCENDING);
            Assert.AreEqual("Andhra Pradesh", sortedList[0].state);
            Assert.AreEqual("West Bengal", sortedList[sortedList.Length  - 1].state);
        }


        [Test]
        public void givenIndianStateCodeCSVToAnalyze_WhenToSort_ShouldReturnSortedList()
        {
            CSVObj.LoadData(INDIAN_STATE_CODE_CSV_PATH,CustomEnums.TYPE.INDIASTATECODE);
            IndianStateCodeDTO[] sortedList = CSVObj.SortData<IndianStateCodeDTO>( CustomEnums.FIELDS.STATECODE, new CustomEnums.TYPE[] {CustomEnums.TYPE.INDIASTATECODE }, CustomEnums.sort.ASCENDING);
            Assert.AreEqual("AD", sortedList[0].stateCode);
            Assert.AreEqual("WB", sortedList[sortedList.Length  - 1].stateCode);
        }
        


        [Test]
        public void givenIndiaStateCensus_AndIndiaStateCodeToAnalyze_WhenTogether_LoadsSuccessfully()
        {
            Dictionary<string, List<CensusDAO>> map = CSVObj.LoadData(INDIAN_CENSUS_CSV_PATH,CustomEnums.TYPE.INDIASTATECENSUS);
            Assert.IsTrue(map.ContainsKey("IndianStateCensusDTO"));
            Assert.IsTrue(map.ContainsKey("IndianStateCodeDTO"));
        }

        [Test]
        public void givenIndiaStateCensusToAnalyze_WhenToSortPopulation_ShouldReturnSortedPopulation()
        {
            Dictionary<string, List<CensusDAO>> map = CSVObj.LoadData(INDIAN_CENSUS_CSV_PATH,CustomEnums.TYPE.INDIASTATECENSUS);
            IndianStateCensusDTO[] sortedList = CSVObj.SortData<IndianStateCensusDTO>( CustomEnums.FIELDS.POPULATION, new CustomEnums.TYPE[] {CustomEnums.TYPE.INDIASTATECENSUS }, CustomEnums.sort.DESCENDING);
            Assert.AreEqual(199812341, sortedList[0].population);
            Assert.AreEqual(607688, sortedList[sortedList.Length-1].population);
        }

        [Test]
        public void givenIndiaStateCensusToAnalyze_WhenToSortPopulationDensity_ShouldReturnSortedPopulationDensity()
        {
            Dictionary<string, List<CensusDAO>> map = CSVObj.LoadData(INDIAN_CENSUS_CSV_PATH,CustomEnums.TYPE.INDIASTATECENSUS);
            IndianStateCensusDTO[] sortedList = CSVObj.SortData<IndianStateCensusDTO>(CustomEnums.FIELDS.DENSITY, new CustomEnums.TYPE[] {CustomEnums.TYPE.INDIASTATECENSUS }, CustomEnums.sort.DESCENDING);
            Assert.AreEqual(1102, sortedList[0].density);
            Assert.AreEqual(50, sortedList[sortedList.Length  - 1].density);
        }

        [Test]
        public void givenIndiaStateCensusToAnalyze_WhenToSortArea_ShouldReturnSortedArea()
        {
            Dictionary<string, List<CensusDAO>> map = CSVObj.LoadData(INDIAN_CENSUS_CSV_PATH,CustomEnums.TYPE.INDIASTATECENSUS);
            IndianStateCensusDTO[] sortedList = CSVObj.SortData<IndianStateCensusDTO>(CustomEnums.FIELDS.AREA, new CustomEnums.TYPE[] {CustomEnums.TYPE.INDIASTATECENSUS }, CustomEnums.sort.DESCENDING);
            Assert.AreEqual(342239, sortedList[0].area);
            Assert.AreEqual(3702, sortedList[sortedList.Length  - 1].area);
        }

        [Test]
        public void givenUSCensusCSVToAnalyze_WhenCorrect_ShouldReturnCount()
        {
            int count = CSVObj.GetCount(US_CENSUS_CSV_PATH, CustomEnums.TYPE.USCENSUS);
            Assert.AreEqual(51, count);
        }


        [Test]
        public void givenUSCensusCSVToAnalyze_WhenIncorrect_ShouldThrowInvalidFileException()
        {
            try
            {
                int count = CSVObj.GetCount(WRONG_US_CENSUS_CSV_PATH, CustomEnums.TYPE.USCENSUS);
            }
            catch (CensusAnalyzerExceptions e)
            {
                Assert.AreEqual(CensusAnalyzerExceptions.ExeptionType.INVALID_FILE, e.ExceptionType);
            }
        }

        [Test]
        public void givenCorrectUSCensusCSVToAnalyze_WhenTypeIncorrect_ShouldThrowInvalidTypeException()
        {
            try
            {
                CSVObj.GetCount(US_CENSUS_CSV_PATH, CustomEnums.TYPE.WRONGTYPE);
            }
            catch (CensusAnalyzerExceptions e)
            {
                Assert.AreEqual(CensusAnalyzerExceptions.ExeptionType.INVALID_TYPE, e.ExceptionType);
            }
        }


        [Test]
        public void givenUSCensusCSVToAnalyze_WhenIncorrectDelimiter_ShouldThrowException()
        {
            try
            {
                CSVObj.LoadData(WRONG_US_CENSUS_CSV_DELIMITER_PATH , CustomEnums.TYPE.USCENSUS);
            }
            catch (CensusAnalyzerExceptions e)
            {
                Assert.AreEqual(CensusAnalyzerExceptions.ExeptionType.INVALID_DELIMITER, e.ExceptionType);
            }
        }


        [Test]
        public void givenUSCensusCSVToAnalyze_WhenIncorrectHeader_ShouldThrowInvalidHeaderException()
        {
            try
            {
                CSVObj.GetCount(WRONG_US_CENSUS_CSV_HEADER_PATH, CustomEnums.TYPE.USCENSUS);
            }
            catch (CensusAnalyzerExceptions e)
            {
                Assert.AreEqual(CensusAnalyzerExceptions.ExeptionType.INVALID_HEADER, e.ExceptionType);
            }
        }


        [Test]
        public void givenUSCensusToAnalyze_WhenToSortPopulation_ShouldReturnSortedPopulation()
        {
            CSVObj.LoadData(US_CENSUS_CSV_PATH, CustomEnums.TYPE.USCENSUS);
            USCensusDTO[] sortedList = CSVObj.SortData<USCensusDTO>( CustomEnums.FIELDS.POPULATION, new CustomEnums.TYPE[] { CustomEnums.TYPE.USCENSUS }, CustomEnums.sort.DESCENDING);
            Assert.AreEqual(37253956, sortedList[0].population);
            Assert.AreEqual(563626, sortedList[sortedList.Length  - 1].population);
        }

        [Test]
        public void givenUSCensusToAnalyze_WhenToSortArea_ShouldReturnSortedPopulation()
        {
            CSVObj.LoadData(US_CENSUS_CSV_PATH, CustomEnums.TYPE.USCENSUS);
            USCensusDTO[] sortedList = CSVObj.SortData<USCensusDTO>(CustomEnums.FIELDS.AREA, new CustomEnums.TYPE[] { CustomEnums.TYPE.USCENSUS }, CustomEnums.sort.DESCENDING);
            Assert.AreEqual(1723338.01d, sortedList[0].area);
            Assert.AreEqual(177.0d, sortedList[sortedList.Length - 1].area);
        }

        [Test]
        public void givenUSCensusToAnalyze_WhenToSortDensity_ShouldReturnSortedPopulation()
        {
            Dictionary<string, List<CensusDAO>> map = CSVObj.LoadData(US_CENSUS_CSV_PATH, CustomEnums.TYPE.USCENSUS);
            USCensusDTO[] sortedList = CSVObj.SortData<USCensusDTO>(CustomEnums.FIELDS.DENSITY,new CustomEnums.TYPE[] { CustomEnums.TYPE.USCENSUS}, CustomEnums.sort.DESCENDING);
            Assert.AreEqual(3805.6100000000001d, sortedList[0].density);
            Assert.AreEqual(0.46000000000000002d, sortedList[sortedList.Length - 1].density);
        }

        [Test]
        public void givenUSCensusAndIndianCensusToAnalyze_WhenToSort_ShouldReturnSortedResult()
        {
            CSVObj.LoadData(US_CENSUS_CSV_PATH, CustomEnums.TYPE.USCENSUS);
            CSVObj.LoadData(INDIAN_CENSUS_CSV_PATH,CustomEnums.TYPE.INDIASTATECENSUS);
            CustomEnums.TYPE[] arr = new CustomEnums.TYPE[] { CustomEnums.TYPE.USCENSUS,CustomEnums.TYPE.INDIASTATECENSUS };
            USCensusDTO[] sortedList = CSVObj.SortData<USCensusDTO>(CustomEnums.FIELDS.POPULATION, arr, CustomEnums.sort.DESCENDING, CustomEnums.FIELDS.DENSITY);
            Assert.AreEqual("Uttar Pradesh", sortedList[0].state);
            Assert.AreEqual("Wyoming", sortedList[sortedList.Length  - 1].state);
        }


        [Test]
        public void givenUSCensusToAnalyze_WhenFileNotFound_ShouldThrowException()
        {
            try
            {
                Dictionary<string, List<CensusDAO>> map = CSVObj.LoadData("c://s.csv", CustomEnums.TYPE.USCENSUS);
            }
            catch (CensusAnalyzerExceptions e){ 
                Assert.AreEqual(CensusAnalyzerExceptions.ExeptionType.FILE_NOT_FOUND, e.ExceptionType);
            }
        }

        [Test]
        public void givenUSCensusToSortDensityToAnalyze_WhenNoSuchData_ShouldThrowException()
        {
            try { 
                USCensusDTO[] sortedList = CSVObj.SortData<USCensusDTO>(CustomEnums.FIELDS.DENSITY, new CustomEnums.TYPE[] { CustomEnums.TYPE.USCENSUS }, CustomEnums.sort.DESCENDING);
            }
            catch (CensusAnalyzerExceptions e)
            {
                Assert.AreEqual(CensusAnalyzerExceptions.ExeptionType.NO_SUCH_DATA, e.ExceptionType);
            }
         }
    }
}