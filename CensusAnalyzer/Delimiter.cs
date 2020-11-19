﻿using CensusAnalyzerProject.Exceptions;
using CensusAnalyzerProject.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CensusAnalyzerProject
{
    public class Delimiter : Loader
    {
        Loader loader;

        /// <summary>
        /// Initializes a new instance of the <see cref="Delimiter"/> class.
        /// </summary>
        /// <param name="loader">Any child class of loader.</param>
        public Delimiter(Loader loader)
        {
            this.loader = loader;
        }

        /// <summary>
        /// Loads the data.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="className">Name of the class.</param>
        /// <returns>String array of CSV data</returns>
        /// <exception cref="CensusAnalyzerExceptions">Throws Invalid delimiter if delimiter is wrong</exception>
        public override string[] LoadData(string path, string className)
        {

            string[] rows = loader.LoadData(path, className);
            {
                foreach (string row in rows)
                    if (!row.Contains(","))
                    {
                        throw new CensusAnalyzerExceptions(CensusAnalyzerExceptions.ExeptionType.INVALID_DELIMITER);
                    }
            }
            return rows;
        }
    }
}
