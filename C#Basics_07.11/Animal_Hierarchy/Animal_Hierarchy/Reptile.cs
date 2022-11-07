using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal_Hierarchy
{
    public class Reptile : Animal
    {

        public int meters { get; set; }
        public Reptile(string name, int age) : base(name, age)
        {
        }

        public override void move()
        {
            Console.WriteLine("The reptile is crawling");
        }

        public override void move(int meters)
        {
            this.meters += meters;
            Console.WriteLine("The reptile took {0} meters", meters);
            Console.WriteLine("Total meters: " + this.meters);
        }
    }
}
