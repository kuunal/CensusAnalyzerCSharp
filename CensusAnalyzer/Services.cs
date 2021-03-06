﻿// <copyright file="Order.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>using CensusAnalyzerProject.DTO;

namespace CensusAnalyzerProject
{
    using CensusAnalyzerProject.Enums;
    using CensusAnalyzerProject.Exceptions;
    using CensusAnalyzerProject.Models;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Reflection;

    /// <summary>
    /// Provides main services like sorting.
    /// </summary>
    public class Services 
    {
        Factory factory = new Factory();
        const string JSON_FILE_PATH = "C:/Users/Vishal/source/repos/CensusAnalyzer/CensusAnalyzerProjectTest/utilities/JSONOP.json";

        /// <summary>
        /// Loads the data.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="type">The type.</param>
        /// <returns>String array of CSV data</returns>
        public Dictionary<string, List<CensusDAO>> LoadData(string path, CustomEnums.TYPE type)
        {
            string className = GetDescription(type);
            string[] data = factory.GetCSVLoader().LoadData(path, className);
            Adaptor adaptor = new Adaptor();
            return adaptor.LoadCSV(data, className);
        }

        /// <summary>
        /// Gets the count of given type of Country data.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="type">The type.</param>
        /// <returns>Count of data</returns>
        public int GetCount(string path, CustomEnums.TYPE type)
        {
            string className = GetDescription(type);
            return LoadData(path, type)[className].Count;
        }

        /// <summary>
        /// Sorts the data.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fieldName">Name of the field.</param>
        /// <param name="classNames">The class names.</param>
        /// <param name="sorttype">The sorttype.</param>
        /// <param name="anotherField">Another field.</param>
        /// <returns>DTO object</returns>
        public T[] SortData<T>(CustomEnums.FIELDS fieldName, CustomEnums.TYPE[] classNames, CustomEnums.sort sorttype, CustomEnums.FIELDS? anotherField = null)
        {
            string field = GetDescription(fieldName);
            List<string> classNameList = new List<string>();
            foreach(CustomEnums.TYPE type in classNames)
            {
                classNameList.Add(GetDescription(type));
            }
            List<CensusDAO> list = GetMergedList(classNameList);
            ISort sortObj = factory.GetSort(sorttype);
            List<CensusDAO> sortedList = sortObj.sort(list, field);
            if (CustomEnums.sort.DESCENDING.Equals(sorttype))
            {
                sortedList.Reverse();
            }
            string data = JsonConvert.SerializeObject(sortedList);
            T[] d = JsonConvert.DeserializeObject<T[]>(data);
            string data1 = JsonConvert.SerializeObject(d); 
            File.WriteAllText(JSON_FILE_PATH, data1);
            return d;
        }

        /// <summary>
        /// Gets the merged list of two different countries.
        /// </summary>
        /// <param name="classNames">The class names.</param>
        /// <returns>Data of two countries in list</returns>
        /// <exception cref="CensusAnalyzerExceptions"></exception>
        public List<CensusDAO> GetMergedList(List<string> classNames)
        {
            List<CensusDAO> list = new List<CensusDAO>();
            Adaptor ad = new Adaptor();
            Dictionary<string, List<CensusDAO>> dict = ad.GetCensusDict();
            foreach (string className in classNames)
            {
                try { 
                    list.AddRange(dict[className]);
                }
                catch (System.Collections.Generic.KeyNotFoundException)
                {
                    throw new CensusAnalyzerExceptions(CensusAnalyzerExceptions.ExeptionType.NO_SUCH_DATA);
                }
            }
            return list;
        }

        /// <summary>
        /// Gets the description of enum.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>String value of enum description</returns>
        public string GetDescription(dynamic type)
        {
            FieldInfo field = type.GetType().GetField(type.ToString());
            var attr = field.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return (attr[0] as DescriptionAttribute).Description;
        }
    }
}
