// See https://aka.ms/new-console-template for more information
using Application;
using Application.Hobby.Commands.Create;
using Application.Logger;
using Application.Notifications;
using Domain.Entity;
using Domain.Interfaces;
using Hobby_Project;
using MediatR;

public class Program
{
    public static void Main()
    {
        /*
        Logger logger = Logger.Instance;
        logger.LogMessage("create", "Ivan post new hobby with title: It was a great day!");
        logger.ReadMessages("create");

       
        logger.LogMessage("delete", "Ivan delete hobby with title: It was a great day!");
        logger.ReadMessages("delete");
        */

       //create hobby

        /*
        Console.WriteLine("Hello, World!");

        Dictionary<int, List<ISubscriber>> keyValuePairs = new Dictionary<int, List<ISubscriber>>();
        List<HobbyComment> hobbyComments = new List<HobbyComment>();
        List<Tag> tags = new List<Tag>();
        HobbyPublisher publisher = new HobbyPublisher(keyValuePairs);

        ISubscriber subscriber1 = new NotificationUser();
        ISubscriber subscriber2 = new NotificationUser();
        HobbySubCategory hobbySubCategory = new HobbySubCategory(1, "Voleyball");
        List<ISubscriber> subscribers = new List<ISubscriber>();
        keyValuePairs.Add(hobbySubCategory.Id, subscribers);
        publisher.AddSubscriber(1, subscriber1);
        publisher.AddSubscriber(1, subscriber2);

        HobbyArticle hobbyArticle = new HobbyArticle("Last Voleyball game", "It was a great time", hobbySubCategory, hobbyComments, tags);
        publisher.Publish(hobbyArticle);
        */
    }
}


