using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal_Hierarchy
{
    public class Bird : Animal
    {
        public int meters { get; set; }
        public Bird(string name, int age) : base(name, age)
        {

        }

        public override void move()
        {
            Console.WriteLine("The bird is flying");
        }

        public override void move(int meters)
        {
            this.meters += meters;
            Console.WriteLine("The bird flied {0} meters", meters);
            Console.WriteLine("Total meters "+ meters);
        }
    }
}
