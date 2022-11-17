using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesProject
{
    internal interface IPlanetExtender
    {
        void ClearFormatting()
        {
            Console.WriteLine("------------"); 
        }
    }
}
