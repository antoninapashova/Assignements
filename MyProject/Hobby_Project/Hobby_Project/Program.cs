
using Hobby_Project;
using Hobby_Project.Exceptions;

using System.Security.Cryptography.X509Certificates;

public class Program
{
    public static void Main()
    {
        HobbySubCategory hobbySubCategory = new HobbySubCategory("dlkpsakd");
        User user = new User("skadlksajd", "dkawdkaod", "dajsaodjo", "dasjpdoaod", 8);
        user.AddNewHobby(new Hobby("dlsk;lksa", "dmflkadk", hobbySubCategory));
        user.AddNewHobby(new Hobby("dlskdfds;lksa", "dmflkadk", hobbySubCategory));
        user.AddNewHobby(new Hobby("dlsk;lksa", "dmflkefwefadk", hobbySubCategory));
        List<Hobby> hobbies1 = user.Hobbies;
        Hobby hobby = new Hobby("dlsk;lksa", "dmflkadk", hobbySubCategory);
        user.RemoveHobbyByName("dlskdfds;lksa");
        List<Hobby> hobbies = user.Hobbies;
    }

    
    public static void createHobby(string title, string description, HobbySubCategory hobbySubCategory)
    {
        try
        {
            var hobby = new Hobby(title, description, hobbySubCategory);
        }
        catch (NullReferenceException ex)
        {
           Console.WriteLine(ex.Message);
         }
        
        catch (HobySubCategoryDoesNotSetException ex)
        
        {
           Console.WriteLine(ex.Message);
        }
        
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
