using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyzerProject
{
    public interface ICount
    {
        public int GetCount(string path, string className);
    }
}
