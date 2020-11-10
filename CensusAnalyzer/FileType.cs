using CensusAnalyzerProject.Exceptions;
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

        public override ArrayList LoadData(string path, string className)
        {
            VerifyCSV(path);
            return base.LoadData(path, className);
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
