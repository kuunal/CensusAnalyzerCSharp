using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyzerProject.DTO
{
    public class IndianStateCensusDTO
    {
        public string state;
        public long population;
        public long areaInSquareKiloMeter;
        public long densityPerSquareKiloMeter;
        
        public IndianStateCensusDTO(string[] values)
        {
            this.state = values[0];
            this.areaInSquareKiloMeter = long.Parse(values[1]);
            this.population = long.Parse(values[2]);
            this.densityPerSquareKiloMeter = long.Parse(values[3]);
        }
    }
}
