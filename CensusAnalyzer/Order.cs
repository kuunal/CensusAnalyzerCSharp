using CensusAnalyzerProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CensusAnalyzerProject
{
    /// <summary>
    /// Implements ISort's method and does sorting based on given fields.
    /// </summary>
    /// <seealso cref="CensusAnalyzerProject.ISort" />
    public class Order : ISort
    {
        /// <summary>
        /// Sorts the specified fields.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="field">The field.</param>
        /// <param name="anotherField">Secondary field to sort.</param>
        /// <returns>Sorted list of Census DAO</returns>
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
