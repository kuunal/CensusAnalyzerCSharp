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

        public Dictionary<string, List<string>> LoadData(string path, string className)
        {
            Dictionary<string, List<string>> map = new Dictionary<string, List<string>>();
            List<string> data = new List<string>();
            if (File.Exists(path))
            {
                using (StreamReader streamReader = new StreamReader(path)) { 
                    while (!streamReader.EndOfStream)
                    {
                        data.Add(streamReader.ReadLine());
                    }
                }
                map.Add(className, data);
            }
            return map;
        }
    }
}
