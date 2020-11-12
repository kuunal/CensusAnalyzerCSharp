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
        public long areaInSquareKiloMeter;
        public long densityPerSquareKiloMeter;
        public int srNo;
        public string stateCode;
        public string stateName;
        public int tIN;

        public CensusDAO(IndianStateCensusDTO indianStateCensus)
        {
            this.state = indianStateCensus.state;
            this.population = indianStateCensus.population;
            this.areaInSquareKiloMeter = indianStateCensus.areaInSquareKiloMeter;
            this.densityPerSquareKiloMeter = indianStateCensus.densityPerSquareKiloMeter;
        }

        public CensusDAO(IndianStateCodeDTO indianStateCodeDAO)
        {
            this.srNo = indianStateCodeDAO.srNo;
            this.stateCode = indianStateCodeDAO.stateCode;
            this.stateName = indianStateCodeDAO.stateName;
            this.tIN = indianStateCodeDAO.tIN;
        }

        //public IndianStateCensusDTO GetStateCensusDTO() { 
            
        //}

    }
}
