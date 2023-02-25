using Application.Repositories;
using Domain.Entity;
using Hobby_Project;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class HobbyPhotoRepository : IPhotoRepository
    {
        private readonly HobbyDbContext _context;

        public HobbyPhotoRepository(HobbyDbContext context)
        {
            _context = context;
        }

        public async Task<Photo> Add(Photo entity)
        {
           await _context.Photos.AddAsync(entity);
            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            var hobbyPhoto = await FindById(id);
            _context.Photos.Remove(hobbyPhoto);
        }

        public async Task<IEnumerable<Photo>> GetAllEntitiesAsync()
        {
            return _context.Photos.AsEnumerable();
        }

        public async Task<Photo> GetByIdAsync(int id)
        {
            Photo hobbyPhoto = await FindById(id);
            return await Task.FromResult(hobbyPhoto);
        }
        public async Task<Photo> Update(Photo entity)
        {
            await FindById(entity.Id);
            _context.Photos.Update(entity);
            return entity;
        }

        public async Task<Photo> FindById(int id)
        {
            var photo = await _context.Photos.FirstOrDefaultAsync(c => c.Id == id);

            if (photo == null)
                throw new InvalidOperationException("Photo with Id" + id + "does not exist!");

            return photo;
        }
    }
}
