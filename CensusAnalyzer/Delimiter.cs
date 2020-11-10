using CensusAnalyzerProject.Exceptions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyzerProject
{
    public class Delimiter : Decorator
    {
        public Delimiter(ICensusCSVLoader censusCSVLoader) : base(censusCSVLoader) { }
        public override ArrayList LoadData(string path, string className)
        {
            ArrayList data = base.LoadData(path, className);
            if (!data[0].ToString().Contains(","))
            {
                throw new CensusAnalyzerExceptions(CensusAnalyzerExceptions.ExeptionType.INVALID_DELIMITER);
            }
            return data;
        }
    }
}
