using CensusAnalyzerProject.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyzerProject
{
    public interface CountryAdaptor
    {
        public List<CensusDAO> CSVParser(string[] rows, string className);
    }
}
