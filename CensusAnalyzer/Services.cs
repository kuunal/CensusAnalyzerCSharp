using CensusAnalyzerProject.DTO;
using CensusAnalyzerProject.Enums;
using CensusAnalyzerProject.Models;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CensusAnalyzerProject
{
    public class Services : Decorator, ICount
    {
        const string JSON_FILE_PATH = "C:/Users/Vishal/source/repos/CensusAnalyzer/CensusAnalyzerProjectTest/utilities/JSONOP.json";
        string path;
        public Services(ICensusCSVLoader censusCSVLoader) : base(censusCSVLoader) { }

    

        public override Dictionary<string, List<CensusDAO>> LoadData(string path, string className)
        {
            this.path = path;
            return base.LoadData(path, className);
        }

        public int GetCount(string path, string className)
        {
            return LoadData(path, className)[className].Count;
        }

        public List<CensusDAO> SortData(string field, string className, CustomEnums.sort sorttype)
        {
            Factory factory = new Factory();
            ISort sortObj = factory.GetSort(sorttype);
            Dictionary<string, List<CensusDAO>> dict = LoadData(path, className);
            List<CensusDAO> list = dict[className];
            List<CensusDAO> sortedList = sortObj.sort(list, field);
            if (CustomEnums.sort.DESCENDING.Equals(sorttype))
            {
                sortedList.Reverse();
            }
            string data = JsonConvert.SerializeObject(sortedList);
            File.WriteAllText(JSON_FILE_PATH, data);
            return sortedList;
        }
    }
}
