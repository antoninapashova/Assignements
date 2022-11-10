// See https://aka.ms/new-console-template for more information
using System.Globalization;

public class Program
{
     public static void Main()
     {
        DateTime dateTime = new DateTime();
        TimeSpan timeSpan = new TimeSpan();
        Console.WriteLine(TimeSpan.FromDays(3));
        Console.WriteLine(timeSpan.ToString());
        Console.WriteLine(DateTimeOffset.MinValue);
        Console.WriteLine(TimeZone.CurrentTimeZone.ToString());
        Console.WriteLine(CultureInfo.InvariantCulture.ToString());
        
     }
}
