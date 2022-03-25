using System;

namespace SolarFarm.Core
{
    public class Panel
    {
        public string Section { get; set; }

        public int Row { get; set; }
        
        public int Column { get; set; }
        
        public DateTime Year { get; set; }

        public bool IsTracking { get; set; }

        public Material Material { get; set; }
    }
}
