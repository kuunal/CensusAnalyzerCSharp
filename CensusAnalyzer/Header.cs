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
    public class Header : Loader
    {
        Loader loader;
        public Header(Loader loader)
        {
            this.loader = loader;
        }

        public override string[] LoadData(string path, string className)
        {
            string[] rows = loader.LoadData(path, className);
            ValidateHeaders(rows[0], className);
            return rows;
        }

        public void ValidateHeaders(string headers, string className)
        {
            string[] headerArray = headers.Split(",");
            Type type = Type.GetType("CensusAnalyzerProject.DTO." + className);
            FieldInfo[] fields = type.GetFields(); 
            foreach(FieldInfo field in fields)
            {
                if (!Array.Exists<string>(headerArray, header => header.ToLower().Equals(field.Name.ToLower())))
                {
                    throw new CensusAnalyzerExceptions(CensusAnalyzerExceptions.ExeptionType.INVALID_HEADER);
                }
            }
        }

    }
}
