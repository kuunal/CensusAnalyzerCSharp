using CensusAnalyzerProject.DTO;
using CensusAnalyzerProject.Enums;
using CensusAnalyzerProject.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyzerProject
{
    public class Factory
    {
        public ISort GetSort(CustomEnums.sort sorttype)
        {
                return new Order();
        }
    

    public Loader GetCSVLoader()
        {
            Loader censusAnalyzerObj;
            Loader delimiterObj;
            Loader typeObj;
            Loader headerObj;
            Loader filetype;
            censusAnalyzerObj = new Loader();
            delimiterObj = new Delimiter(censusAnalyzerObj);
            typeObj = new CSVType(delimiterObj);
            headerObj = new Header(typeObj);
            filetype = new FileType(headerObj);
            return filetype;
        }

        public CountryAdaptor GetCountryCensus(string className)
        {
            switch (className)
            {
                case "USCensusDTO":
                    return new USAdaptee();
                case "IndianStateCodeDTO":
                case "IndianStateCensusDTO":
                    return new IndianAdaptee();
                default:
                    throw new CensusAnalyzerExceptions(CensusAnalyzerExceptions.ExeptionType.INVALID_TYPE);
            }
        }
    }
}
