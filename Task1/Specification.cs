using System;
using System.Collections.Generic;
using System.Linq;

namespace Task1Platform
{
    public class Specification : ICloneable, IRequirement
    {
        public Specification(string text)
        {
            this.Text = text;
            this.UserStoryList = new List<UserStory>();
            this.PrototypeList = new List<Prototype>();
        }

        public Specification()
        {
            this.Text = string.Empty;
            this.UserStoryList = new List<UserStory>();
            this.PrototypeList = new List<Prototype>();
        }

        public string Text
        {
            get; set;
        }

        public string ProductName
        {
            get
            {
                return this.Text.Split(new char[] { ' ' })[0];
            }

            set
            {
                this.ProductName = value;
            }
        }

        public List<UserStory> UserStoryList
        {
            get; set;
        }

        public List<Prototype> PrototypeList
        {
            get; set;
        }

        public void AddUserStory(UserStory userStory)
        {
            this.UserStoryList.Add(userStory);
        }

        public void AddPrototype(Prototype prototype)
        {
            this.PrototypeList.Add(prototype);
        }

        public int CompareTo(object obj)
        {
            Specification specification = obj as Specification;
            if (specification != null)
            {
                return this.ProductName.CompareTo(specification.ProductName);
            }
            else
            {
                throw new Exception("comparer error Spacification");
            }
        }

        public object Clone()
        {
            return new Specification()
            {
                Text = string.Copy(this.Text),
                UserStoryList = new List<UserStory>(this.UserStoryList.Select(x => (UserStory)x.Clone())),
                PrototypeList = new List<Prototype>(this.PrototypeList.Select(x => (Prototype)x.Clone()))
            };
        }

        public string WriteRequirement()
        {
            string specification = this.Text + "\n";
            foreach (UserStory item in this.UserStoryList)
            {
                specification += item.WriteRequirement() + "\n";
            }

            foreach (Prototype item in this.PrototypeList)
            {
                specification += item.WriteRequirement() + "\n";
            }

            return specification;
        }

        public object ReadRequirement(string line)
        {
            return new Specification(line);
        }
    }
}
