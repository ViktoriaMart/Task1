using System;

namespace Task1Platform
{
    public interface IRequirement : IComparable
    {
        string ProductName
        {
            get;
        }

        string WriteRequirement();

        object ReadRequirement(string line);

        new int CompareTo(object obj);
    }
}
