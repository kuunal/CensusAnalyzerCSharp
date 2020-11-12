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
        public override Dictionary<string, List<IndianStateCensus>> LoadData(string path, string className)
        {
            using (StreamReader reader = new StreamReader(path)) 
            {
                string data = reader.ReadLine();
                if (!data.ToString().Contains(",") )
                {
                    throw new CensusAnalyzerExceptions(CensusAnalyzerExceptions.ExeptionType.INVALID_DELIMITER);
                }
            }
            return base.LoadData(path, className);
        }
    }
}
