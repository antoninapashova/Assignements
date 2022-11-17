using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesProject
{
    public delegate void MyDelegate();
    public delegate void MySecondDelegate(int n, int m);
    public delegate string CalculateVolume(int x, int z, int y);
}
