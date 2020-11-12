using CensusAnalyzerProject.Exceptions;
using CensusAnalyzerProject.Models;
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

        public override Dictionary<string, List<IndianStateCensus>> LoadData(string path, string className)
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
            string[] headerArray = headers.Split(",");
            Type type = Type.GetType("CensusAnalyzerProject.DTO." + className);
            FieldInfo[] fields = type.GetFields(); 
            foreach(string header in headerArray)
            {
                if (!Array.Exists<FieldInfo>(fields, field => header.ToLower().Equals(field.Name.ToLower())))
                {
                    throw new CensusAnalyzerExceptions(CensusAnalyzerExceptions.ExeptionType.INVALID_HEADER);
                }
            }
        }

    }
}
