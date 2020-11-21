// <copyright file="Factory.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CensusAnalyzerProject
{
    using CensusAnalyzerProject.Enums;
    using CensusAnalyzerProject.Exceptions;

    /// <summary>
    /// Objects provider.
    /// </summary>
    public class Factory
    {
        /// <summary>
        /// Gets the sort.
        /// </summary>
        /// <param name="sorttype">The sorttype.</param>
        /// <returns></returns>
        public ISort GetSort(CustomEnums.sort sorttype)
        {
                return new Order();
        }

        /// <summary>
        /// Gets the loader.
        /// </summary>
        /// <returns>Loader object</returns>
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

        /// <summary>
        /// Gets the Adaptee.
        /// </summary>
        /// <param name="className">Name of the class.</param>
        /// <returns>Adaptee class based on classname</returns>
        /// <exception cref="CensusAnalyzerExceptions">Throws Invalid type if default case.</exception>
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
