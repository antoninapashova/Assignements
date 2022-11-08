using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hobby_Project
{
    public abstract class CommonProperties
    {
        private string name;

        public string Name
        {
            get { return name; }
            set
            {

                if (!string.IsNullOrWhiteSpace(value))
                {
                    name = value;
                }

            }
        }

        public DateTime AddedOn { get; set; }

        protected CommonProperties(string name, DateTime addedOn)
        {
            this.name = name;
            this.AddedOn = addedOn;
        }

    

        public abstract void editName();

        public abstract void changeName(string newName);
    }
}
