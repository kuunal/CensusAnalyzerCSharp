// <copyright file="CensusAnalyzerExceptions.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CensusAnalyzerProject.Exceptions
{
    using System;
    public class CensusAnalyzerExceptions : Exception
    {
        /// <summary>
        /// Exception type for census analzyer
        /// </summary>
        public enum ExeptionType{
            INVALID_FILE,
            INVALID_TYPE,
            INVALID_DELIMITER,
            INVALID_HEADER,
            FILE_NOT_FOUND,
            NO_SUCH_DATA,
            INVALID_DATA
        }
        public Enum ExceptionType;

        /// <summary>
        /// Initializes a new instance of the <see cref="CensusAnalyzerExceptions"/> class.
        /// </summary>
        /// <param name="ExceptionType">Type of the exception.</param>
        public CensusAnalyzerExceptions(Enum ExceptionType) : base(ExceptionType.ToString())
        {
            this.ExceptionType = ExceptionType;
        }
    }
}
