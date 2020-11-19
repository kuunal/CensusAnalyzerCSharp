using CensusAnalyzerProject.Exceptions;
using CensusAnalyzerProject.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyzerProject.DTO
{
    public class IndianStateCensusDTO
    {
        public string state;
        public long population;
        public long area;
        public long density;
        
        public IndianStateCensusDTO() { }

        public IndianStateCensusDTO(string[] values)
        {
            try { 
                this.state = values[0];
                this.area= long.Parse(values[2]);
                this.population = long.Parse(values[1]);
                this.density= long.Parse(values[3]);
            }
            catch (System.FormatException)
            {
                throw new CensusAnalyzerExceptions(CensusAnalyzerExceptions.ExeptionType.INVALID_DATA);
            }
        }
    }
}
