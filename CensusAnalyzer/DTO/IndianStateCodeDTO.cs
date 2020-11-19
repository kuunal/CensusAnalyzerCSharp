using CensusAnalyzerProject.Exceptions;
using CensusAnalyzerProject.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyzerProject.DTO
{
    public class IndianStateCodeDTO
    {
        public int srNo;
        public string stateName;
        public string stateCode;
        public int tIN;

        public IndianStateCodeDTO() { }

        public IndianStateCodeDTO(string[] values)
        {
            try { 
                this.srNo = Convert.ToInt32(values[0]);
                this.stateCode = values[3];
                this.stateName = values[1];
                this.tIN = Convert.ToInt32(values[2]);
            }
            catch (System.FormatException)
            {
                throw new CensusAnalyzerExceptions(CensusAnalyzerExceptions.ExeptionType.INVALID_DATA);
            }
        }
    }
}
