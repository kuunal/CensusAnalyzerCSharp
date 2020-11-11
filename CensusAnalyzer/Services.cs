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

    

        public override ArrayList LoadData(string path, string className)
        {
            return base.LoadData(path, className);
        }

        public int GetCount(string path, string className)
        {
            return LoadData(path, className).Count-1;
        }

        public ArrayList SortData(ArrayList list, string field)
        {
            Factory factory = new Factory();
            ISort sortObj = factory.GetSort();
            ArrayList sortedList = sortObj.sort(list, field);
            string data = JsonConvert.SerializeObject(sortedList);
            File.WriteAllText(JSON_FILE_PATH, data);
            return sortedList;
        }
    }
}
