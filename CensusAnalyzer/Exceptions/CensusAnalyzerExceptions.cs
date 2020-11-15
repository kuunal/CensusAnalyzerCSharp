using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyzerProject.Exceptions
{
    public class CensusAnalyzerExceptions : Exception
    {
        public enum ExeptionType{
            INVALID_FILE,
            INVALID_TYPE,
            INVALID_DELIMITER,
            INVALID_HEADER,
            FILE_NOT_FOUND
        }
        public Enum ExceptionType;
        public CensusAnalyzerExceptions(Enum ExceptionType) : base(ExceptionType.ToString())
        {
            this.ExceptionType = ExceptionType;
        }
    }
}
