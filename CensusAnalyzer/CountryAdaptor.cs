using CensusAnalyzerProject.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyzerProject
{
    /// <summary>
    /// Common parent for adaptees and abstraction for StoreData method.
    /// </summary>
    public interface CountryAdaptor
    {
        public List<CensusDAO> StoreData(string[] rows, string className);
    }
}
