using CensusAnalyzerProject.Exceptions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyzerProject
{
    public class CSVType : Decorator
    {
        public CSVType(ICensusCSVLoader censusCSVLoader) : base(censusCSVLoader)
        {
        }

        public override ArrayList LoadData(string path, string className)
        {
            verifyType("CensusAnalyzerProject.Models." + className);
            return base.LoadData(path, className);
        }

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
