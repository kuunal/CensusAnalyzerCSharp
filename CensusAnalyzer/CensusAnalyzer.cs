using CensusAnalyzerProject.DTO;
using CensusAnalyzerProject.Exceptions;
using CensusAnalyzerProject.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CensusAnalyzerProject
{
    public class CensusAnalyzer : ICensusCSVLoader
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }



        public Dictionary<string, List<IndianStateCensus>> LoadData(string path, string className)
        {
            List<IndianStateCensus> data = new List<IndianStateCensus>();
            Dictionary<string, List<IndianStateCensus>> map = new Dictionary<string, List<IndianStateCensus>>();
            if (File.Exists(path))
            {
                string[] rows = File.ReadAllLines(path);
                foreach (string record in rows.Skip(1)) {   
                    string[] values = record.Split(",");
                    if (className == "IndianStateCensusDTO")
                        data.Add(new IndianStateCensus(new IndianStateCensusDTO(values)));
                    else
                        data.Add(new IndianStateCensus(new IndianStateCodeDTO(values)));
                }

            }
                map.Add(className, data);
            
            return map;
        }
    }
}
