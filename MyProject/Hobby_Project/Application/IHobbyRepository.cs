

using Domain.Entity;

namespace Application
{
    public interface IHobbyRepository
    {
        void CreateHobby(HobbyArticle hobbyArticle);
        void DeleteHobby(HobbyArticle hobbyArticle);
        HobbyArticle DeleteHobbyById(int hobbyId);
        void EditHobby(int hobbyId, string title, string description);
        HobbyArticle GetHobby(int hobbyId);
        List<HobbyArticle> GetAllHobbies();
    }
}
