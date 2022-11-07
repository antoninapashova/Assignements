using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal_Hierarchy
{
    public abstract class Animal
    {
        public string Name { get; set; }
        public int age;
        public int Age
        {
            get { return age; }
            set
            {
                if(value > 0 && value < 60)
                {
                    age = value;
                }
            }
        }

        public Animal(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
        public abstract void move();
        public abstract void move(int moves);

        public virtual void eat()
        {
            Console.WriteLine("The {0} is eating", this.Name);
        }
        
    }
}
