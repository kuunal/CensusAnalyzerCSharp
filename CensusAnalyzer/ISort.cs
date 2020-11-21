// <copyright file="ISort.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>


namespace CensusAnalyzerProject
{
    using CensusAnalyzerProject.Models;
    using System.Collections.Generic;

    /// <summary>
    /// Provides sorting for Censusanalyzer
    /// </summary>
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
