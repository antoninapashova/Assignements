using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesProject
{
    public class Planet : IPlanetExtender
    {
        public long Mass { get; set; }
        public string Name { get; set; } 
        public int? DaysAroundTheSum { get; set; }
        public double? OxygenPercentage { get; set; }
        public double WaterPercentage { get; set; }
        public int MaxDegrees { get; set; }
        public int MinDegrees { get; set; }

        public PlanetType Type { get; set; }

    }
}
