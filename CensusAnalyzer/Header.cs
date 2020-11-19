using CensusAnalyzerProject.Exceptions;
using CensusAnalyzerProject.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace CensusAnalyzerProject
{
    public class Header : Loader
    {
        Loader loader;

        /// <summary>
        /// Initializes a new instance of the <see cref="Header"/> class.
        /// </summary>
        /// <param name="loader">The loader.</param>
        public Header(Loader loader)
        {
            this.loader = loader;
        }

        /// <summary>
        /// Loads the data.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="className">Name of the class.</param>
        /// <returns>String array of CSV data</returns>
        public override string[] LoadData(string path, string className)
        {
            string[] rows = loader.LoadData(path, className);
            ValidateHeaders(rows[0], className);
            return rows;
        }

        /// <summary>
        /// Validates the headers based on DTO fields.
        /// </summary>
        /// <param name="headers">The headers.</param>
        /// <param name="className">Name of the class.</param>
        /// <exception cref="CensusAnalyzerExceptions">Throws INVALID_HEADER if not matched with fields</exception>
        public void ValidateHeaders(string headers, string className)
        {
            string[] headerArray = headers.Split(",");
            Type type = Type.GetType("CensusAnalyzerProject.DTO." + className);
            FieldInfo[] fields = type.GetFields(); 
            foreach(FieldInfo field in fields)
            {
                if (!Array.Exists<string>(headerArray, header => header.ToLower().Equals(field.Name.ToLower())))
                {
                    throw new CensusAnalyzerExceptions(CensusAnalyzerExceptions.ExeptionType.INVALID_HEADER);
                }
            }
        }

    }
}
