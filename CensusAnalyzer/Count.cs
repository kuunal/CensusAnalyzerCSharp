using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyzerProject
{
    public class Count : Decorator, ICount
    {
        public Count(ICensusCSVLoader censusCSVLoader) : base(censusCSVLoader) { }

    

        public override ArrayList LoadData(string path, string className)
        {
            return base.LoadData(path, className);
        }

        public int GetCount(string path, string className)
        {
            return LoadData(path, className).Count-1;
        }
    }
}
