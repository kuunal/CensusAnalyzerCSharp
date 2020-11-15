using CensusAnalyzerProject.DTO;
using CensusAnalyzerProject.Enums;
using CensusAnalyzerProject.Models;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace CensusAnalyzerProject
{
    public class Services : Decorator, ICount
    {
        const string JSON_FILE_PATH = "C:/Users/Vishal/source/repos/CensusAnalyzer/CensusAnalyzerProjectTest/utilities/JSONOP.json";
        public Services(ICensusCSVLoader censusCSVLoader) : base(censusCSVLoader) { }

    

        public override Dictionary<string, List<CensusDAO>> LoadData(string path, string className)
        {
            return base.LoadData(path, className);
        }

        public int GetCount(string path, string className)
        {
            return LoadData(path, className)[className].Count;
        }

        public T[] SortData<T>(string field, string[] classNames, CustomEnums.sort sorttype, string anotherField = null)
        {
            Factory factory = new Factory();
            List<CensusDAO> list = GetMergedList(classNames);
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

        public List<CensusDAO> GetMergedList(string[] classNames)
        {
            List<CensusDAO> list = new List<CensusDAO>();
            Adaptor ad = new Adaptor();
            Dictionary<string, List<CensusDAO>> dict = ad.GetCensusDict();
            foreach (string className in classNames)
            {
                list.AddRange(dict[className]);
            }
            return list;
        }
    }
}
