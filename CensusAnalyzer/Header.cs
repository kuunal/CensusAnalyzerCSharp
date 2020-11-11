using CensusAnalyzerProject.Exceptions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace CensusAnalyzerProject
{
    public class Header : Decorator
    {
        public Header(ICensusCSVLoader censusCSVLoader) : base(censusCSVLoader)
        {
        }

        public override ArrayList LoadData(string path, string className)
        {
            ArrayList data = base.LoadData(path, className);
            ValidateHeaders(data[0].ToString(), className);
            return data;
        }

        public void ValidateHeaders(string headers, string className)
        {
            string[] header = headers.Split(",");
            Type type = Type.GetType("CensusAnalyzerProject.Models." + className);
            PropertyInfo[] properties = type.GetProperties();
            foreach(PropertyInfo property in properties)
            {
                if (!Array.Exists<string>(header, rawHeaders => rawHeaders.Equals(property)))
                {
                    throw new CensusAnalyzerExceptions(CensusAnalyzerExceptions.ExeptionType.INVALID_HEADER);
                }
            }
        }

    }
}
