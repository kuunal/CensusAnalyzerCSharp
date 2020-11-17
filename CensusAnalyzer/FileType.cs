using CensusAnalyzerProject.Exceptions;
using CensusAnalyzerProject.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CensusAnalyzerProject
{
    public class FileType : Decorator
    {
        const string ALLOWED_EXTENSION = ".csv";

        public FileType(ICensusCSVLoader censusCSVLoader) : base(censusCSVLoader)
        {
        }

        public override Dictionary<string, List<CensusDAO>> ParseCSV(string[] rows, string className, string path)
        {
            VerifyCSV(path);
            return base.ParseCSV(rows, className, path);
        }

        public void VerifyCSV(string path)
        {
            string fileExtension = Path.GetExtension(path);
            if (!fileExtension.Equals(ALLOWED_EXTENSION))
            {
                throw new CensusAnalyzerExceptions(CensusAnalyzerExceptions.ExeptionType.INVALID_FILE);
            }
        }

    }
}
