using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal_Hierarchy
{
    public class Mammal : Animal

    {
        public int steps { get; set; }
        public Mammal(string name, int age) : base(name, age)
        {
        }

        /*
        public override void eat()
        {
            Console.WriteLine("The animal is eating");
        }
        */
        public override void move()
        {
           Console.WriteLine("The mamamal is walking");
        }

        public override void move(int steps)
        {
            this.steps += steps;
            Console.WriteLine("The mammal took {0} steps", steps);
            Console.WriteLine("Total steps: " + this.steps);
        }
    }
}
