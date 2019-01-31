using System;

namespace Task1Platform
{

    public class Prototype : ICloneable, IRequirement
    {
        public Prototype(string productName, string fileName, string fileSize)
        {
            this.ProductName = productName;
            this.FileName = fileName;
            this.FileSize = fileSize;
        }

        public Prototype()
        {
            this.ProductName = string.Empty;
            this.FileName = string.Empty;
            this.FileSize = string.Empty;
        }

        public string ProductName
        {
            get;
        }

        public string FileName
        {
            get; set;
        }

        public string FileSize
        {
            get; set;
        }

        public int CompareTo(object obj)
        {
            Prototype userStory = obj as Prototype;
            if (userStory != null)
            {
                return this.FileSize.CompareTo(userStory.FileSize);
            }
            else
            {
                throw new Exception("comparer error in Prototype");
            }
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public string WriteRequirement()
        {
            return this.ProductName + " " + this.FileName + " " + this.FileSize;
        }

        public object ReadRequirement(string line)
        {
            string[] elements = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            return new Prototype(elements[0], elements[1], elements[2]);
        }
    }
}
