using CensusAnalyzerProject;
using NUnit.Framework;


namespace CensusAnalyzerProjectTest
{
    public class CensusAnalyzerTest
    {
        const string INDIAN_CENSUS_CSV_PATH = "C:/Users/Vishal/source/repos/CensusAnalyzer/CensusAnalyzerProjectTest/utilities/IndiaStateCensusData.csv";

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void givenIndianCensusCSV_WhenCorrect_ReturnsNumberOfRecords()
        {
            CensusAnalyzer censusAnalyzerObj = new CensusAnalyzer();
            int count = censusAnalyzerObj.GetCount(INDIAN_CENSUS_CSV_PATH);
            Assert.AreEqual(29, count);
        }
    }
}