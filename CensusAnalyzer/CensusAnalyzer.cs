using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace CensusAnalyzerProject
{
    public class CensusAnalyzer
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int GetCount(string path)
        {
            ArrayList CSVData = new ArrayList();
            if (File.Exists(path))
            {
                using (StreamReader streamReader = new StreamReader(path)) { 
                    while (!streamReader.EndOfStream)
                    {
                        CSVData.Add(streamReader.ReadLine());
                    }
                }
            }
            return CSVData.Count-1;
        }
    }
}
