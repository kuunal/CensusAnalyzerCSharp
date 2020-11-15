using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CensusAnalyzerProject.Enums
{
    public class CustomEnums
    {
        public enum sort { 
        ASCENDING, DESCENDING
        }

        public enum TYPE
        {
            [Description("USCensusDTO")]
            USCENSUS,
            [Description("IndianStateCodeDTO")]
            INDIASTATECODE,
            [Description("IndianStateCensusDTO")]
            INDIASTATECENSUS,
            [Description("wrong")]
            WRONGTYPE
        }

        public enum FIELDS
        {
            [Description("state")] 
            STATE,

            [Description("population")]
            POPULATION,

            [Description("area")]
            AREA,

            [Description("density")]
            DENSITY,

            [Description("srNo")]
            SRNO,

            [Description("tIN")]
            TIN,

            [Description("stateCode")]
            STATECODE
        }
    }
}
