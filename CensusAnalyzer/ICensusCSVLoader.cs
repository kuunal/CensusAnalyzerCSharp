using CensusAnalyzerProject.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyzerProject
{
    public interface ICensusCSVLoader   
    {
        public Dictionary<string, List<CensusDAO>> ParseCSV(string[] data, string className, string path=null);
    }
}
