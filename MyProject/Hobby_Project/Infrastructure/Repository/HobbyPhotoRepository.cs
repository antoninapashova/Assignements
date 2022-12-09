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
    internal class HobbyPhotoRepository : IPhotoRepository
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

            HobbyPhoto hobbyPhoto = await IsValid(id);
            _context.HobbyPhotos.Remove(hobbyPhoto);
        }

        public async Task<IQueryable<HobbyPhoto>> GetAllEntitiesAsync()
        {
            return _context.HobbyPhotos;
        }

        public async Task<HobbyPhoto> GetByIdAsync(int id)
        {
            HobbyPhoto result = await IsValid(id);

            return result;
        }

        public async Task UpdateAsync(int id, HobbyPhoto entity)
        {
            //TO DO
        }

        private async Task<HobbyPhoto> IsValid(int photoId)
        {
            if (photoId <= 0) throw new NullReferenceException("Photo Id must be positive");
            var photo = await _context.HobbyPhotos.FirstOrDefaultAsync(c => c.Id == photoId);
            if (photo == null) throw new InvalidOperationException("Photo with Id" + photoId + "does not exist!");
            return photo;
        }
    }
}
