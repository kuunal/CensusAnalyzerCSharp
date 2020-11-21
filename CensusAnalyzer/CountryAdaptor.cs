// <copyright file="CountryAdaptor.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CensusAnalyzerProject
{
    using CensusAnalyzerProject.Models;
    using System.Collections.Generic;

    /// <summary>
    /// Common parent for adaptees and abstraction for StoreData method.
    /// </summary>
    public interface CountryAdaptor
    {
        public List<CensusDAO> StoreData(string[] rows, string className);
    }
}
