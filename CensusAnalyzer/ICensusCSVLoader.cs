using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyzerProject
{
    public interface ICensusCSVLoader   
    {
        public Dictionary<string, List<string>> LoadData(string path, string className);
    }
}
