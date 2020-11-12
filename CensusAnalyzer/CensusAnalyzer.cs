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

        static Dictionary<string, List<CensusDAO>> map = new Dictionary<string, List<CensusDAO>>();


        public Dictionary<string, List<CensusDAO>> LoadData(string path, string className)
        {
            List<CensusDAO> data = new List<CensusDAO>();
            if (File.Exists(path))
            {
                string[] rows = File.ReadAllLines(path);
                foreach (string record in rows.Skip(1)) {   
                    string[] values = record.Split(",");
                    switch(className){
                        case "IndianStateCensusDTO":
                            data.Add(new CensusDAO(new IndianStateCensusDTO(values)));
                            break;
                        case "USCensusDTO":
                            data.Add(new CensusDAO(new USCensusDTO(values)));
                            break;
                        case "IndianStateCodeDTO":
                            data.Add(new CensusDAO(new IndianStateCodeDTO(values)));
                            break;
                        default:
                            throw new CensusAnalyzerExceptions(CensusAnalyzerExceptions.ExeptionType.INVALID_HEADER);
                    }
                }
            }
            try { 
                map.Add(className, data);
            }
            catch (System.ArgumentException)
            {
                map[className] = data;
            }
            return map;
        }
    }
}
