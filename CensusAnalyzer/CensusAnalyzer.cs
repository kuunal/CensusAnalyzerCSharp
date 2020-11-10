using CensusAnalyzerProject.Exceptions;
using CensusAnalyzerProject.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace CensusAnalyzerProject
{
    public class CensusAnalyzer
    {
        const string ALLOWED_EXTENSION = ".csv";
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int GetCount(string path, string className)
        {
            VerifyCSV(path);
            verifyType("CensusAnalyzerProject.Models." + className);
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

        public void VerifyCSV(string path)
        {
            string fileExtension = Path.GetExtension(path); 
            if (!fileExtension.Equals(ALLOWED_EXTENSION))
            {
                throw new CensusAnalyzerExceptions(CensusAnalyzerExceptions.ExeptionType.INVALID_FILE);
            }
        }

        public void verifyType(string className)
        {   
            Type type = Type.GetType(className);
            if (type == null)
            {
                throw new CensusAnalyzerExceptions(CensusAnalyzerExceptions.ExeptionType.INVALID_TYPE);
            }
        }
    }
}
