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

        /// <summary>
        /// Initializes a new instance of the <see cref="IndianStateCodeDTO"/> class.
        /// </summary>
        /// <param name="values">Values array with valid csv data.</param>
        /// <exception cref="CensusAnalyzerExceptions">Throws Invalid data if data is in wrong format</exception>
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
