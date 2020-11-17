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
