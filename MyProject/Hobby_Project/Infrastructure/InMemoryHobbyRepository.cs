using Application;
using Domain.Entity;
using Hobby_Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    internal class InMemoryHobbyRepository : IHobbyRepository
    {
        List<HobbyArticle> hobbyArticles = new();
        public void CreateHobby(HobbyArticle hobbyArticle)
        {
            hobbyArticles.Add(hobbyArticle);
        }

        public void DeleteHobby(HobbyArticle hobbyArticle)
        {
            var hobbyArticle1 = hobbyArticles.FirstOrDefault(h=>h.ID==hobbyArticle.ID);
            if (hobbyArticle1 == null) throw new InvalidOperationException("HobbyArticle with ID: " + hobbyArticle.ID + "does not exist");
            hobbyArticles.Remove(hobbyArticle);
        }

        public void EditHobby(int hobbyId, HobbyArticle hobbyArticle)
        {
            var hobbyArticle1 = isValid(hobbyId);
            hobbyArticle1.Title = hobbyArticle.Title;
            hobbyArticle1.Description = hobbyArticle1.Description;
            hobbyArticle1.AddedOn = DateTime.Now;
            hobbyArticle1.Comments = hobbyArticle.Comments;
            hobbyArticle1.HobbySubCategory = hobbyArticle.HobbySubCategory;
            hobbyArticle1.Tags = hobbyArticle.Tags;
            
        }

        public List<HobbyArticle> GetAllHobbies()
        {
            return hobbyArticles;
        }

        public HobbyArticle GetHobby(int hobbyId)
        {
            var hobbyArticle = isValid(hobbyId);
            return hobbyArticle;
        }

        private HobbyArticle isValid(int ID)
        {
            var hobby = hobbyArticles.FirstOrDefault(h => h.ID == ID);
            if (hobby == null) throw new InvalidOperationException("HobbyArticle with ID: " + ID + "does not exist");
            return hobby;
        }
    }
}
