// <copyright file="Adaptor.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CensusAnalyzerProject
{
    using CensusAnalyzerProject.Models;
    using System.Collections.Generic;

    /// <summary>
    /// Loads different types of data
    /// </summary>
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
    