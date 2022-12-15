using Domain.Entity;
using Hobby_Project;
using HobbyProject.Application.Categories.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ISubscriber
    {
        public int Id { get; set; }
        void Notify(HobbySubCategory hobbySubCategory);
    }
}
