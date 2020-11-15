using CensusAnalyzerProject.DTO;
using CensusAnalyzerProject.Enums;
using CensusAnalyzerProject.Exceptions;
using CensusAnalyzerProject.Models;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Text;

namespace CensusAnalyzerProject
{
    public class Services 
    {
        Factory factory = new Factory();
        const string JSON_FILE_PATH = "C:/Users/Vishal/source/repos/CensusAnalyzer/CensusAnalyzerProjectTest/utilities/JSONOP.json";

    

        public Dictionary<string, List<CensusDAO>> LoadData(string path, CustomEnums.TYPE type)
        {
            string className = GetDescription(type);
            return factory.GetCSVLoader().LoadData(path, className);
        }

        public int GetCount(string path, CustomEnums.TYPE type)
        {
            string className = GetDescription(type);
            return LoadData(path, type)[className].Count;
        }

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

        public string GetDescription(dynamic type)
        {
            FieldInfo field = type.GetType().GetField(type.ToString());
            var attr = field.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return (attr[0] as DescriptionAttribute).Description;
        }
    }
}
