using CensusAnalyzerProject.DTO;
using CensusAnalyzerProject.Exceptions;
using CensusAnalyzerProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CensusAnalyzerProject
{
    class USAdaptee : CountryAdaptor
    {
        public Dictionary<string, List<CensusDAO>> CSVParser(string[] rows, string className)
        {
            Dictionary<string, List<CensusDAO>> censusData = new Dictionary<string, List<CensusDAO>>();
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
                try
                {
                    censusData.Add(className, data);
                }
                catch (System.ArgumentException)
                {
                    censusData[className] = data;
                }
                return censusData;
            }
        }
    }
}
