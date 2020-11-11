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
        public Services(ICensusCSVLoader censusCSVLoader) : base(censusCSVLoader) { }

    

        public override Dictionary<string, List<string>> LoadData(string path, string className)
        {
            return base.LoadData(path, className);
        }

        public int GetCount(string path, string className)
        {
            return LoadData(path, className)[className].Count-1;
        }

        public List<string> SortData(Dictionary<string, List<string>> dict, string field, string className)
        {
            Factory factory = new Factory();
            ISort sortObj = factory.GetSort();
            List<string> list = dict[className];
            List<string> sortedList = sortObj.sort(list, field);
            string data = JsonConvert.SerializeObject(sortedList);
            File.WriteAllText(JSON_FILE_PATH, data);
            return sortedList;
        }
    }
}
