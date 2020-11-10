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
        public virtual ArrayList LoadData(string path, string className)
        {
            return censusCSVLoader.LoadData(path, className);
        }

    }
}
