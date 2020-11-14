using CensusAnalyzerProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CensusAnalyzerProject
{
    public class Order : ISort
    {
        public List<CensusDAO> sort(List<CensusDAO> data, string field, string anotherField)
        {
            Type type = typeof(CensusDAO);
            var fields = type.GetField(field);
            try { 
                var anotherfields = type.GetField(anotherField);
                return data.OrderBy(row => fields.GetValue(row)).ThenBy(row => anotherfields.GetValue(row)).ToList();
            }
            catch (System.ArgumentNullException) { 
                return data.OrderBy(row => fields.GetValue(row)).ToList();
            }
        }
    }
}
