using System;

namespace Task1Platform
{
    public class UserStory : ICloneable, IRequirement
    {
        public UserStory()
        {
            this.ProductName = string.Empty;
            this.TextOfUserStory = string.Empty;
        }

        public UserStory(string productName, string userStoryName, string textOfUserStory)
        {
            this.ProductName = productName;
            this.UserStoryName = userStoryName;
            this.TextOfUserStory = textOfUserStory;
        }

        public string ProductName
        {
            get;
        }

        public string UserStoryName
        {
            get; set;
        }

        public string TextOfUserStory
        {
            get; set;
        }

        public int CompareTo(object obj)
        {
            UserStory userStory = obj as UserStory;
            if (userStory != null)
            {
                return this.ProductName.CompareTo(userStory.ProductName);
            }
            else
            {
                throw new Exception("comparer error in UserStory");
            }
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public string WriteRequirement()
        {
            return this.ProductName + " " + this.UserStoryName + " " + this.TextOfUserStory;
        }

        public object ReadRequirement(string line)
        {
            string[] elements = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            line = string.Empty;
            for (int i = 2; i < elements.Length; i++)
            {
                line += elements[i];
            }

            return new UserStory(elements[0], elements[1], line);
        }
    }
}