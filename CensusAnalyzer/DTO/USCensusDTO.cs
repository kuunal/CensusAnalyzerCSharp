using CensusAnalyzerProject.Exceptions;
using CensusAnalyzerProject.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyzerProject.DTO
{
    public class USCensusDTO
    {
        public string state;
        public long population;
        public double area;
        public double density;

        public USCensusDTO() { }


        /// <summary>
        /// Initializes a new instance of the <see cref="USCensusDTO"/> class.
        /// </summary>
        /// <param name="values">Values array with valid csv data.</param>
        /// <exception cref="CensusAnalyzerExceptions">Throws Invalid data if data is in wrong format.</exception>
        public USCensusDTO(string[] values)
        {
            try { 
                this.state = values[1];
                this.population = long.Parse(values[2]);
                this.area = double.Parse(values[4]);
                this.density = double.Parse(values[7]);
               }
            catch (System.FormatException)
            {
                throw new CensusAnalyzerExceptions(CensusAnalyzerExceptions.ExeptionType.INVALID_DATA);
            }
        }
    }

}
