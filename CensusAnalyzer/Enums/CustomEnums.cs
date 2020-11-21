// <copyright file="CustomEnums.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>


namespace CensusAnalyzerProject.Enums
{
    using System.ComponentModel;

    /// <summary>
    /// Contains all enums of census analyzer.
    /// </summary>
    public class CustomEnums
    {
        /// <summary>
        /// Sorting type
        /// </summary>
        public enum sort { 
        ASCENDING, DESCENDING
        }

        /// <summary>
        /// Type of data
        /// </summary>
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

        /// <summary>
        /// Fields of DAO
        /// </summary>
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
