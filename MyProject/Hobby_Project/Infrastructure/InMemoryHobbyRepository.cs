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
    public class InMemoryHobbyRepository : IHobbyRepository
    {
        List<HobbyArticle> hobbyArticles = new();
        public void CreateHobby(HobbyArticle hobbyArticle)
        {
            hobbyArticles.Add(hobbyArticle);
        }

        public void DeleteHobby(HobbyArticle hobbyArticle)
        {
            var hobbyArticle1 = hobbyArticles.FirstOrDefault(h=>h.Id==hobbyArticle.Id);
            if (hobbyArticle1 == null) throw new InvalidOperationException("HobbyArticle with ID: " + hobbyArticle.Id + "does not exist");
            hobbyArticles.Remove(hobbyArticle);
        }

        public HobbyArticle DeleteHobbyById(int hobbyId)
        {
            HobbyArticle hobbyArticle = isValid(hobbyId);
            hobbyArticles.Remove(hobbyArticle);
            return hobbyArticle;
        }

        public void EditHobby(int hobbyId, string title, string description)
        {
            var hobbyArticle1 = isValid(hobbyId);
            hobbyArticle1.Title = title;
            hobbyArticle1.Description = description;
            hobbyArticle1.AddedOn = DateTime.Now;
            
            
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
            var hobby = hobbyArticles.FirstOrDefault(h => h.Id == ID);
            if (hobby == null) throw new InvalidOperationException("HobbyArticle with ID: " + ID + "does not exist");
            return hobby;
        }
    }
}
