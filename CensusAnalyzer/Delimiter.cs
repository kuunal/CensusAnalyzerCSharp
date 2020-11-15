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
        public override Dictionary<string, List<CensusDAO>> LoadData(string path, string className)
        {
            if (File.Exists(path))
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    string data = reader.ReadLine();
                    if (!data.ToString().Contains(","))
                    {
                        throw new CensusAnalyzerExceptions(CensusAnalyzerExceptions.ExeptionType.INVALID_DELIMITER);
                    }
                }
            }
            else
                throw new CensusAnalyzerExceptions(CensusAnalyzerExceptions.ExeptionType.FILE_NOT_FOUND);
            return base.LoadData(path, className);
        }
    }
}
