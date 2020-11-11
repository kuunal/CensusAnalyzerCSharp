using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyzerProject
{
    public class Factory
    {
        public ISort GetSort()
        {
            return new QuickSort();
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
            filetype = new FileType(censusAnalyzerObj);
            typeObj = new CSVType(filetype);
            delimiterObj = new Delimiter(typeObj);
            headerObj = new Header(delimiterObj);
            countObj = new Services(headerObj);
            return countObj;
        }
    }
}
