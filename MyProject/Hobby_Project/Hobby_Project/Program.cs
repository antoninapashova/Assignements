
using Hobby_Project;
using Hobby_Project.Exceprtions;
using System.Security.Cryptography.X509Certificates;

public class Program
{
    public static void Main()
    {
        HobbySubCategory hobbySubCategory = new HobbySubCategory("VolleyBall", DateTime.Now);
        createHobby("", "........", hobbySubCategory);
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
