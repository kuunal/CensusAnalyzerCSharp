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
    public class Adaptor : Loader, ICensusCSVLoader
    {
        static Dictionary<string, List<CensusDAO>> dict = new Dictionary<string, List<CensusDAO>>();

        public new Dictionary<string, List<CensusDAO>> LoadData(string path, string className)
        {
            string[] rows= base.LoadData(path, className);
            Factory factory = new Factory();
            CountryAdaptor adaptorObj = factory.GetCountryCensus(className);
            Dictionary<string, List<CensusDAO>> censusDict = adaptorObj.CSVParser(rows, className);
            try
            {
                dict.Add(className, censusDict[className]);
            }
            catch (System.ArgumentException)
            {
                dict[className] = censusDict[className];
            }
            return dict;
        }
    }
}
    