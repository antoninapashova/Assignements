
using Hobby_Project;
using Hobby_Project.Exceptions;

using System.Security.Cryptography.X509Certificates;

public class Program
{
    public static void Main()
    {
        HobbySubCategory volleyball = new HobbySubCategory("Volleyball" );
        HobbySubCategory photography = new HobbySubCategory("Photography");
        HobbyComment hobbyComment = new HobbyComment("Wedding", "Very nice pictures");
        List<HobbyComment> comments = new List<HobbyComment>();
        comments.Add(hobbyComment);
        Hobby[] sportHobbies = new[]
        {
            new Hobby("Last Volleyball Game",comments, "It was a greate time", volleyball),
            new Hobby("New people in our team", comments, "We have 3 new people in our tema", volleyball),
        };

        Hobby[] photographyHobbies = new[]
        {
        new Hobby("Wedding",comments, "I took a great pictures of Maria`s wedding day", photography),
        new Hobby("Birthday",comments, "It was 18 birthday of Ana", photography),

        };

        Hobby[] volleyballHobbies = sportHobbies.Where(x => x.HobbySubCategory.Name.Equals("Volleyball")).ToArray();
       

        IEnumerable<Hobby> firstThreeHobbies = sportHobbies.Take(1);
    
        IEnumerable<Hobby> skipMethod = sportHobbies.Skip(1);
        IEnumerable<Hobby> takeWhileMethod = sportHobbies.TakeWhile(h => h.HobbySubCategory.Name.Equals("Volleyball"));
        IEnumerable<Hobby> skipWhileMethod = sportHobbies.SkipWhile(h => h.HobbySubCategory.Name.Equals("Volleyball"));
        IEnumerable<Hobby> distinctMethod = sportHobbies.Distinct();
        IEnumerable<string> titles = photographyHobbies.Select(h=>h.Title);
        IEnumerable<Hobby> photographyCollection= photographyHobbies.Where(h => h.HobbySubCategory.Name.Equals("Photography"));
        var hobbyComments = photographyHobbies.SelectMany(h => h.Comments);

        var ascendingOrder = photographyHobbies.OrderBy(hobbyComment => hobbyComment.Title);
        foreach (var h in photographyHobbies)
        {
           // Console.WriteLine(h.t + " " + h.Title);
            //Console.WriteLine(h);
            Console.WriteLine($"Title: {h.Title}\nDescription: {h.Description}\nSubcategory: {h.HobbySubCategory.Name}");

        }
    }

    
    public static void createHobby(string title, string description, HobbySubCategory hobbySubCategory)
    {
        try
        {
            Hobby hobby = new Hobby(title, description, hobbySubCategory);
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
