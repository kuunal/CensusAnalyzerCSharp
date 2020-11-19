using CensusAnalyzerProject.DTO;
using CensusAnalyzerProject.Enums;
using CensusAnalyzerProject.Exceptions;
using CensusAnalyzerProject.Models;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CensusAnalyzerProject
{
    public class Adaptor 
    {
        internal static Dictionary<string, List<CensusDAO>> dict = new Dictionary<string, List<CensusDAO>>();

        /// <summary>
        /// Makes the census dictionary available for other classes.
        /// </summary>
        /// <returns></returns>
        internal Dictionary<string, List<CensusDAO>>  GetCensusDict()
        {
            return dict;
        }

        /// <summary>
        /// Loads the CSV file into dictionary.
        /// </summary>
        /// <param name="rows">String array with CSV data.</param>
        /// <param name="className">Name of the class.</param>
        /// <returns>Dictionary with classname and CSVData</returns>
        public Dictionary<string, List<CensusDAO>> LoadCSV(string[] rows, string className)
        {
            Factory factory = new Factory();
            CountryAdaptor adaptorObj = factory.GetCountryCensus(className);
            List<CensusDAO> censusList = adaptorObj.StoreData(rows, className);
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
    