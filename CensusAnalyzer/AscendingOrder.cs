using CensusAnalyzerProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CensusAnalyzerProject
{
    public class AscendingOrder : ISort
    {
        public List<CensusDAO> sort(List<CensusDAO> data, string field)
        {
            Type type = typeof(CensusDAO);
            var fields = type.GetField(field);
            return data.OrderBy(row => fields.GetValue(row)).ToList();
        }
    }
}
