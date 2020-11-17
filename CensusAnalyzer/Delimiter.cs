using CensusAnalyzerProject.Exceptions;
using CensusAnalyzerProject.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CensusAnalyzerProject
{
    public class Delimiter : Decorator
    {
        public Delimiter(ICensusCSVLoader censusCSVLoader) : base(censusCSVLoader) { }
        public override Dictionary<string, List<CensusDAO>> ParseCSV(string[] rows, string className, string path=null)
        {
            {
                foreach(string row in rows)
                if (!row.Contains(","))
                {
                    throw new CensusAnalyzerExceptions(CensusAnalyzerExceptions.ExeptionType.INVALID_DELIMITER);
                }
            }
            return base.ParseCSV(rows, className);
        }
    }
}
