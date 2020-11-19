using CensusAnalyzerProject.DTO;
using CensusAnalyzerProject.Exceptions;
using CensusAnalyzerProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CensusAnalyzerProject
{
    class IndianAdaptee : CountryAdaptor
    {
        /// <summary>
        /// Stores the data using INDIANSTATECENSUS or INDIANSTATECODE DTO.
        /// </summary>
        /// <param name="rows">The rows.</param>
        /// <param name="className">Name of the class.</param>
        /// <returns>List of CENSUSDAO object.</returns>
        /// <exception cref="CensusAnalyzerExceptions"></exception>
        public List<CensusDAO> StoreData(string[] rows, string className)
        {
            Dictionary<string, List<CensusDAO>> censusData = new Dictionary<string, List<CensusDAO>>();
            List<CensusDAO> data = new List<CensusDAO>();
            {
                foreach (string record in rows.Skip(1))
                {
                    string[] values = record.Split(",");
                    switch (className)
                    {
                        case "IndianStateCensusDTO":
                            data.Add(new CensusDAO(new IndianStateCensusDTO(values)));
                            break;
                        case "IndianStateCodeDTO":
                            data.Add(new CensusDAO(new IndianStateCodeDTO(values)));
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
