using CensusAnalyzerProject.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyzerProject
{
    public class Decorator : ICensusCSVLoader
    {
        private ICensusCSVLoader censusCSVLoader;

        public Decorator(ICensusCSVLoader censusCSVLoader)
        {
            this.censusCSVLoader = censusCSVLoader;
        }
        public virtual Dictionary<string, List<CensusDAO>> ParseCSV(string[] rows, string className, string path=null)
        {
            return censusCSVLoader.ParseCSV(rows, className, path);
        }

    }
}
