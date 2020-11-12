using CensusAnalyzerProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CensusAnalyzerProject
{
    public class DescendingOrder : ISort
    {
        public List<CensusDAO> sort(List<CensusDAO> data, string field)
        {
            Type type = typeof(CensusDAO);
            var fields = type.GetField(field);
            return data.OrderByDescending(row => fields.GetValue(row)).ToList();
        }
    }
}
