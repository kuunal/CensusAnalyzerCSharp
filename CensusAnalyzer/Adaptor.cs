using CensusAnalyzerProject.DTO;
using CensusAnalyzerProject.Exceptions;
using CensusAnalyzerProject.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CensusAnalyzerProject
{
    public class Adaptor : ICensusCSVLoader
    {
        static Dictionary<string, List<CensusDAO>> dict = new Dictionary<string, List<CensusDAO>>();

        public Dictionary<string, List<CensusDAO>>  GetCensusDict()
        {
            return dict;
        }

        public Dictionary<string, List<CensusDAO>> LoadData(string path, string className)
        {
            Loader loader = new Loader();
            string[] rows= loader.LoadData(path, className);
            Factory factory = new Factory();
            CountryAdaptor adaptorObj = factory.GetCountryCensus(className);
            List<CensusDAO> censusList = adaptorObj.CSVParser(rows, className);
            try
            {
                dict.Add(className, censusList);
            }
            catch (System.ArgumentException)
            {
                dict[className] = censusList;
            }
            return dict;
        }
    }
}
    