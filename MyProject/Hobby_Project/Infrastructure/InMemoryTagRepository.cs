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
            tag.ID = _hobbyTags.Count;
        }

        public void DeleteTag(Tag tag)
        {
            var tagForDeletion = _hobbyTags.FirstOrDefault(t => t.ID == tag.ID);
            if (tagForDeletion == null)
            {
                throw new InvalidOperationException("Tag with id: " + tag.ID + " does not exist!!!");
            }

            _hobbyTags.Remove(tagForDeletion);
        }

        public IEnumerable<Tag> GetAllTags()
        {
            return _hobbyTags;
        }

        public Tag GetTag(int tagId)
        {
            var searchedTag = _hobbyTags.FirstOrDefault(t => t.ID == tagId);
            if (searchedTag == null)
            {
                throw new InvalidOperationException("Tag with id: " + tagId + " does not exist!!!");
            }

            return searchedTag;
        }

        public void UpdateTag(int tagId, Tag tag)
        {
            var searchedTag = _hobbyTags.FirstOrDefault(t => t.ID == tagId);
            if (searchedTag == null) throw new InvalidOperationException("Tag with id: " + tag.ID + " does not exist!!!");
            searchedTag.Name = tag.Name;
            
        }
    }
}
