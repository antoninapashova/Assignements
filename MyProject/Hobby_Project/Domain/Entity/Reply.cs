using Hobby_Project;
using Hobby_Project.Domain.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HobbyProject.Domain.Entity
{
    public class Reply : BaseEntity
    {
        public string Text { get; set; }
        public int UserId { get; set; }
        public virtual UserEntity User { get; set; }
        public int CommentId { get; set; }
        public virtual Comment Comment { get; set; }
    }
}
