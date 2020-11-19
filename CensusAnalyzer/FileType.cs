using CensusAnalyzerProject.Exceptions;
using CensusAnalyzerProject.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CensusAnalyzerProject
{
    public class FileType : Loader
    {
        Loader loader;
        public FileType(Loader loader)
        {
            this.loader = loader;
        }
        const string ALLOWED_EXTENSION = ".csv";

        public override string[] LoadData(string path, string className) { 
            VerifyCSV(path);
            return loader.LoadData(path, className);
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
