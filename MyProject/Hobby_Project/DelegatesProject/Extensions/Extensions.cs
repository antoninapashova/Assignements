using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesProject.Extensions
{
    internal static class Extensions
    {

       public static void Analyze(this Planet planet)
        {
            if (planet.IsHabitable())
            {
                Console.WriteLine($"{planet.Name}: current Oxygen levels: {planet.OxygenPercentage:P}, water percentage: {planet.WaterPercentage:P}");
                return;
            }

            Console.WriteLine("The planet is not habitable!");
        }

        public static bool IsHabotableTypeOfPlanet(this PlanetType type) => type == PlanetType.EarthLike;
       
        /*
        public static void ClearFormatting(this IPlanetExtender planetInterface)
        {
            Console.WriteLine("------------");
        }
        */
        private static bool IsHabitable(this Planet planet) => planet.OxygenPercentage>0.2 
            && planet.WaterPercentage>0.5
            && planet.Type.IsHabotableTypeOfPlanet();
    }
}
