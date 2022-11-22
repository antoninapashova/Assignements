using Domain.Entity;
using Domain.Interfaces;
using Hobby_Project.Domain.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hobby_Project
{
    public class HobbySubCategory : BaseEntity, ISubject
    {
        public string Name { get; set; }
        public DateTime AddedOn { get; set; }
        private List<IObserver> _observers;
        private List<HobbyArticle> _hobbyArticles { get; set; }

        public List<HobbyArticle> HobbyArticles
        {
            get { return _hobbyArticles; }
            set
            {
                _hobbyArticles = value;
                Notify();
            }
        }
        public HobbySubCategory(string name)
        {
            Name = name;
            this.AddedOn = DateTime.Now;
            _observers = new List<IObserver>();
            _hobbyArticles = new List<HobbyArticle>();
        }

        public void Attach(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void Notify()
        {
            _observers.ForEach(o => o.Update(this));
        }
    }
}
