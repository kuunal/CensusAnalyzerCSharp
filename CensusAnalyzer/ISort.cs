using CensusAnalyzerProject.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyzerProject
{
    public interface ISort
    {
        /// <summary>
        /// Abstract method for sort.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="field">The field.</param>
        /// <param name="anotherField">Acts as secondary field for sortng.</param>
        /// <returns></returns>
        public List<CensusDAO> sort(List<CensusDAO> data, string field, string anotherField=null);
    }
}
