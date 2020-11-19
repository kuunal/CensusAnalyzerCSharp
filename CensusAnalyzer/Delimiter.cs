using CensusAnalyzerProject.Exceptions;
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
        public Delimiter(Loader loader)
        {
            this.loader = loader;
        }
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
