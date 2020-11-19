using CensusAnalyzerProject.Exceptions;
using CensusAnalyzerProject.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyzerProject
{
    public class CSVType : Loader
    {
        Loader loader;

        /// <summary>
        /// Initializes a new instance of the <see cref="CSVType"/> class.
        /// </summary>
        /// <param name="loader">Any child class of loader.</param>
        public CSVType(Loader loader)
        {
            this.loader = loader;
        }

        /// <summary>
        /// Loads the data.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="className">Name of the class.</param>
        /// <returns>String array of CSV data.</returns>
        public override string[] LoadData(string path, string className)
        {
            verifyType("CensusAnalyzerProject.DTO." + className);
            return loader.LoadData(path, className);
        }


        /// <summary>
        /// Verifies the type.
        /// </summary>
        /// <param name="className">Name of the class.</param>
        /// <exception cref="CensusAnalyzerExceptions">Throws InvalidType</exception>
        public void verifyType(string className)
        {
            Type type = Type.GetType(className);
            if (type == null)
            {
                throw new CensusAnalyzerExceptions(CensusAnalyzerExceptions.ExeptionType.INVALID_TYPE);
            }
        }


    }
}
