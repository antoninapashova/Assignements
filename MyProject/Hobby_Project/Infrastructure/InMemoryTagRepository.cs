using Application;
using Hobby_Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class InMemoryTagRepository : ITagRepository
    {
        List<Tag> _hobbyTags = new();
        public void CreateTag(Tag tag)
        {
            _hobbyTags.Add(tag);
            tag.Id = _hobbyTags.Count;
        }

        public void DeleteTag(Tag tag)
        {
            Tag tagForDeletion = IsValid(tag.Id);

            _hobbyTags.Remove(tagForDeletion);
        }

        public IEnumerable<Tag> GetAllTags()
        {
            return _hobbyTags;
        }

        public Tag GetTag(int tagId)
        {
            Tag tag = IsValid(tagId);

            return tag;
        }

        public void UpdateTag(int tagId, Tag tag)
        {
            Tag searchedTag = IsValid(tagId);
            searchedTag.Name = tag.Name;

        }
        private Tag IsValid(int Id)
        {
            if (Id <= 0) throw new NullReferenceException("Id must be positive!");
            var tag = _hobbyTags.FirstOrDefault(t => t.Id == Id);
            if (tag == null) throw new InvalidOperationException("Tag with id: " + Id + " does not exist!!!");
            return tag;
        }

    }
}
