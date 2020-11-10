using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyzerProject.Models
{
    class IndianStateCensus
    {
        string state { get; set; }
        long population { get; set; }
        long areaInSquareKiloMeter { get; set; }
        long densityPerSquareKiloMeter { get; set; }

    }
}
