using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hobby_Project.Exceprtions
{
     public class HobySubCategoryDoesNotSetException : Exception
    {
        public HobySubCategoryDoesNotSetException(string? message) : base(message)
        {
        }
    }
}
