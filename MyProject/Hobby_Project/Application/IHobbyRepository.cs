

using Domain.Entity;

namespace Application
{
    public interface IHobbyRepository
    {
        void CreateHobby(HobbyArticle hobbyArticle);
        void DeleteHobby(HobbyArticle hobbyArticle);
        void EditHobby(int hobbyId, HobbyArticle hobbyArticle);
        HobbyArticle GetHobby(int hobbyId);
        List<HobbyArticle> GetAllHobbies();
    }
}
