// See https://aka.ms/new-console-template for more information
using Domain.Entity;
using Domain.Interfaces;
using Hobby_Project;

#region example of Obserded Design Pattern
/*
HobbySubCategory hobbySubCategory = new HobbySubCategory("Bastekball");

List<HobbyArticle> articles = new List<HobbyArticle>();
List<HobbyArticle> articles2 = new List<HobbyArticle>();

List<HobbyComment> comments = new List<HobbyComment>(); 

List<Tag> tags = new List<Tag>();

HobbyArticle hobbyArticle = new HobbyArticle("Voley", "Very Interesting game", hobbySubCategory, comments,tags );

IObserver user = new User("Ivannnnn", "Ivan", "Ivan", "ivan@abv.bg", 5, articles);

IObserver user2 = new User("Ivannnnn", "Ivan", "Ivan", "ivan@abv.bg", 5, articles2);
hobbySubCategory.Attach(user2);
articles.Add(hobbyArticle);

user.Update(hobbySubCategory);
*/

#endregion
