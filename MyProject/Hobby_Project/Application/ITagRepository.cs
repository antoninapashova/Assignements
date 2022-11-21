using Hobby_Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public interface ITagRepository
    {
        void CreateTag(Tag tag);
        void UpdateTag(int tagId, Tag tag);
        void DeleteTag(Tag tag);
        Tag GetTag(int tagId);
        IEnumerable<Tag> GetAllTags();


    }
}
