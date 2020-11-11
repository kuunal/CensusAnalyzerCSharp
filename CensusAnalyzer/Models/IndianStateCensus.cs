using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyzerProject.Models
{
    class IndianStateCensus
    {
        public string state { get; set; }
        public long population { get; set; }
        public long areaInSquareKiloMeter { get; set; }
        public long densityPerSquareKiloMeter { get; set; }

    }
}
