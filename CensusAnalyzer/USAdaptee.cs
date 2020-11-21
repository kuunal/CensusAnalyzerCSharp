// <copyright file="Order.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>using CensusAnalyzerProject.DTO;

namespace CensusAnalyzerProject
{
    using CensusAnalyzerProject.DTO;
    using CensusAnalyzerProject.Exceptions;
    using CensusAnalyzerProject.Models;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Loads USCensus data.
    /// </summary>
    /// <seealso cref="CensusAnalyzerProject.CountryAdaptor" />
    class USAdaptee : CountryAdaptor
    {
        /// <summary>
        /// Stores the data of USCensus into list.
        /// </summary>
        /// <param name="rows">The rows.</param>
        /// <param name="className">Name of the class.</param>
        /// <returns>List of UScensus data</returns>
        /// <exception cref="CensusAnalyzerExceptions"></exception>
        public List<CensusDAO> StoreData(string[] rows, string className)
        {
            List<CensusDAO> data = new List<CensusDAO>();
            {
                foreach (string record in rows.Skip(1))
                {
                    string[] values = record.Split(",");
                    switch (className)
                    {
                        case "USCensusDTO":
                            data.Add(new CensusDAO(new USCensusDTO(values)));
                            break;
                        default:
                            throw new CensusAnalyzerExceptions(CensusAnalyzerExceptions.ExeptionType.INVALID_HEADER);
                    }
                }
                return data;
            }
        }
    }
}
