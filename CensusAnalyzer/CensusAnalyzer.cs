using CensusAnalyzerProject.Exceptions;
using CensusAnalyzerProject.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace CensusAnalyzerProject
{
    public class CensusAnalyzer : ICensusCSVLoader
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public ArrayList LoadData(string path, string className)
        {
            Type type = Type.GetType("CensusAnalyzerProject.Models." + className);
            ArrayList data = new ArrayList();
            if (File.Exists(path))
            {
                using (StreamReader streamReader = new StreamReader(path)) { 
                    while (!streamReader.EndOfStream)
                    {
                        data.Add(streamReader.ReadLine());
                    }
                }
            }
            return data;
        }
    }
}
