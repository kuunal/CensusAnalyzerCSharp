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

        public CensusDAO(IndianStateCensusDTO indianStateCensus)
        {
            this.state = indianStateCensus.state;
            this.population = indianStateCensus.population;
            this.area= indianStateCensus.area;
            this.density= indianStateCensus.density;
        }

        public CensusDAO(IndianStateCodeDTO indianStateCodeDAO)
        {
            this.srNo = indianStateCodeDAO.srNo;
            this.stateCode = indianStateCodeDAO.stateCode;
            this.stateName = indianStateCodeDAO.stateName;
            this.tIN = indianStateCodeDAO.tIN;
        }

        public CensusDAO(USCensusDTO uSCensusDTO)
        {
            this.state = uSCensusDTO.state;
            this.population = uSCensusDTO.population;
            this.area = uSCensusDTO.area;
            this.density = uSCensusDTO.density;
        }

    }
}
