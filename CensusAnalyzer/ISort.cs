using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyzerProject
{
    public interface ISort
    {
        public  List<string> sort(List<string> data, string field);
    }
}
