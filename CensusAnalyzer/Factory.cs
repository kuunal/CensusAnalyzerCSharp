using CensusAnalyzerProject.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyzerProject
{
    public class Factory
    {
        public ISort GetSort(CustomEnums.sort sorttype)
        {
            if(CustomEnums.sort.ASCENDING.Equals(sorttype))
            {
                return new AscendingOrder();
            }
            return new DescendingOrder();
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
