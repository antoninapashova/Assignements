using Hobby_Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Commands
{
    public class HobbyDTO
    {
        public int ID {get; set; }
        public string Title;
        public string Description { get; set; }

        public HobbySubCategory HobbySubCategory;
        public DateTime AddedOn { get; set; }
        public List<Tag> Tags { get; set; }
        public List<HobbyComment> Comments { get; set; }
    }
}
