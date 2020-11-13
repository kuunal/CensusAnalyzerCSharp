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
    

    public Services GetCSVLoader()
        {
            ICensusCSVLoader censusAnalyzerObj;
            ICensusCSVLoader filetype;
            Services countObj;
            ICensusCSVLoader delimiterObj;
            ICensusCSVLoader typeObj;
            ICensusCSVLoader headerObj;
            censusAnalyzerObj = new Adaptor();
            headerObj = new Header(censusAnalyzerObj);
            typeObj = new CSVType(headerObj);
            delimiterObj = new Delimiter(typeObj);
            filetype = new FileType(delimiterObj);
            countObj = new Services(filetype);
            return countObj;
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
