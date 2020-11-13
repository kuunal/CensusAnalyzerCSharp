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
    public class Loader 
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }


        public string[] LoadData(string path, string className)
        {
            string[] rows = File.ReadAllLines(path);
            return rows;   
        }

    }
}
