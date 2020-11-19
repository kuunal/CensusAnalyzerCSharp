using CensusAnalyzerProject.DTO;
using CensusAnalyzerProject.Exceptions;
using CensusAnalyzerProject.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CensusAnalyzerProject
{
    public class Loader 
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        /// <summary>
        /// Loads the CSV data into sting array.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="className">Name of the class.</param>
        /// <returns>String array of CSV data</returns>
        /// <exception cref="CensusAnalyzerExceptions"></exception>
        public virtual string[] LoadData(string path, string className)
        {
            if (File.Exists(path))
            {
                string[] rows = File.ReadAllLines(path);
                return rows;
            }
            else
                throw new CensusAnalyzerExceptions(CensusAnalyzerExceptions.ExeptionType.FILE_NOT_FOUND);
        }

    }
}
