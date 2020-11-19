using System;
using System.Collections.Generic;
using System.Text;
using CensusAnalyzerProject.DTO;

namespace CensusAnalyzerProject.Models
{
    public class CensusDAO
    {
        public string state;
        public long population;
        public int srNo;
        public string stateCode;
        public string stateName;
        public int tIN;
        public double area;
        public double density;

        /// <summary>
        /// Initializes a new instance of the <see cref="CensusDAO"/> class.
        /// </summary>
        /// <param name="indianStateCensus">IndianStateCensusDTO object for storing IndianCensus data.</param>
        public CensusDAO(IndianStateCensusDTO indianStateCensus)
        {
            this.state = indianStateCensus.state;
            this.population = indianStateCensus.population;
            this.area= indianStateCensus.area;
            this.density= indianStateCensus.density;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CensusDAO"/> class.
        /// </summary>
        /// <param name="indianStateCodeDAO">IndianStateCodeDTO object for storing indian state data.</param>
        public CensusDAO(IndianStateCodeDTO indianStateCodeDAO)
        {
            this.srNo = indianStateCodeDAO.srNo;
            this.stateCode = indianStateCodeDAO.stateCode;
            this.stateName = indianStateCodeDAO.stateName;
            this.tIN = indianStateCodeDAO.tIN;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CensusDAO"/> class.
        /// </summary>
        /// <param name="uSCensusDTO">USCensus object for storing UScensus data.</param>
        public CensusDAO(USCensusDTO uSCensusDTO)
        {
            this.state = uSCensusDTO.state;
            this.population = uSCensusDTO.population;
            this.area = uSCensusDTO.area;
            this.density = uSCensusDTO.density;
        }

    }
}
