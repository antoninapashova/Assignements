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

        public async Task<HobbyPhoto> Add(HobbyPhoto entity)
        {
           await _context.HobbyPhotos.AddAsync(entity);
            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            await IsValidId(id);
            var hobbyPhoto = await FindById(id);
            _context.HobbyPhotos.Remove(hobbyPhoto);
        }

        public async Task<IEnumerable<HobbyPhoto>> GetAllEntitiesAsync()
        {
            return _context.HobbyPhotos.AsEnumerable();
        }

        public async Task<HobbyPhoto> GetByIdAsync(int id)
        {
            await IsValidId(id);
            HobbyPhoto hobbyPhoto = await FindById(id);
            return await Task.FromResult(hobbyPhoto);
        }
        public async Task<HobbyPhoto> Update(HobbyPhoto entity)
        {
            await IsValidId(entity.Id);

            _context.HobbyPhotos.Update(entity);
            return entity;
        }

        public async Task<HobbyPhoto> FindById(int id)
        {
            var photo = await _context.HobbyPhotos.FirstOrDefaultAsync(c => c.Id == id);

            if (photo == null)
                throw new InvalidOperationException("Photo with Id" + id + "does not exist!");

            return photo;
        }

        public Task<bool> IsValidId(int id)
        {
            if (id <= 0) throw new NullReferenceException("Photo Id must be positive");

            return Task.FromResult(true);
        }
    }
}
