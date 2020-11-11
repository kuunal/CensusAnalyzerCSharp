using CensusAnalyzerProject.Exceptions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace CensusAnalyzerProject
{
    public class Header : Decorator
    {
        public Header(ICensusCSVLoader censusCSVLoader) : base(censusCSVLoader)
        {
        }

        public override Dictionary<string, List<string>> LoadData(string path, string className)
        {
            using (StreamReader reader = new StreamReader(path))
            {
                string data = reader.ReadLine();
                ValidateHeaders(data, className);
            }
                return base.LoadData(path, className);
        }

        public void ValidateHeaders(string headers, string className)
        {
            string[] header = headers.Split(",");
            Type type = Type.GetType("CensusAnalyzerProject.Models." + className);
            PropertyInfo[] properties = type.GetProperties(); 
            foreach(PropertyInfo property in properties)
            {
                if (!Array.Exists<string>(header, rawHeaders => rawHeaders.ToLower().Equals(property.Name.ToLower())))
                {
                    throw new CensusAnalyzerExceptions(CensusAnalyzerExceptions.ExeptionType.INVALID_HEADER);
                }
            }
        }

    }
}
