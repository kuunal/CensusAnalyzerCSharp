using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyzerProject
{
    public class Factory
    {
        public ISort GetSort()
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
            censusAnalyzerObj = new CensusAnalyzer();
            headerObj = new Header(censusAnalyzerObj);
            typeObj = new CSVType(headerObj);
            delimiterObj = new Delimiter(typeObj);
            filetype = new FileType(delimiterObj);
            countObj = new Services(filetype);
            return countObj;
        }
    }
}
