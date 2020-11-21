// <copyright file="FileType.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CensusAnalyzerProject
{
    using CensusAnalyzerProject.Exceptions;
    using System.IO;

    /// <summary>
    /// Checks the extension of file.
    /// </summary>
    /// <seealso cref="CensusAnalyzerProject.Loader" />
    public class FileType : Loader
    {
        Loader loader;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileType"/> class.
        /// </summary>
        /// <param name="loader">The loader.</param>
        public FileType(Loader loader)
        {
            this.loader = loader;
        }
        const string ALLOWED_EXTENSION = ".csv";

        /// <summary>
        /// Loads the data.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="className">Name of the class.</param>
        /// <returns>String array of CSV data</returns>
        public override string[] LoadData(string path, string className) { 
            VerifyCSV(path);
            return loader.LoadData(path, className);
        }

        /// <summary>
        /// Verifies the CSV extension.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <exception cref="CensusAnalyzerExceptions">INVALID_FILE if not extension .csv</exception>
        public void VerifyCSV(string path)
        {
            string fileExtension = Path.GetExtension(path);
            if (!fileExtension.Equals(ALLOWED_EXTENSION))
            {
                throw new CensusAnalyzerExceptions(CensusAnalyzerExceptions.ExeptionType.INVALID_FILE);
            }
        }

    }
}
