using CensusAnalyzerProject.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyzerProject
{
    public interface ISort
    {
        public  List<CensusDAO> sort(List<CensusDAO> data, string field);
    }
}
