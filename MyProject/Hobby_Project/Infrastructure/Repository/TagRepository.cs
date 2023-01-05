using Application.Repositories;
using Hobby_Project;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class TagRepository : ITagRepository
    {
        private readonly HobbyDbContext _context;

        public TagRepository(HobbyDbContext context)
        {
            _context = context;
        }

        public async Task<Tag> Add(Tag entity)
        {
            await _context.Tags.AddAsync(entity);
            return entity;
        }

        public async Task DeleteAsync(int id)
        {
             Tag tagForDeletion = await FindById(id);
             _context.Tags.Remove(tagForDeletion);
        }

        public async Task<IEnumerable<Tag>> GetAllEntitiesAsync()
        {
            return await _context.Tags.ToListAsync();
        }

        public async Task<Tag> GetByIdAsync(int id)
        {
           Tag tag = await FindById(id);
           return tag;
        }

        public async Task<Tag> Update(Tag entity)
        {
            Tag tagForUpdating = await FindById(entity.Id);
            _context.Update(tagForUpdating);
            return entity;
        }
        public async Task<Tag> FindById(int id)
        {
            var tag = await _context.Tags.FirstOrDefaultAsync(t => t.Id == id);

            if (tag == null) 
                throw new NullReferenceException("Tag with id: " + id + " does not exist!");

            return tag;
        }
    }
}
