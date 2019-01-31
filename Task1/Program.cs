using System;
using System.Collections.Generic;
using System.IO;

namespace Task1Platform
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<IRequirement> userStoryList = new List<IRequirement>();
            List<IRequirement> prototypeList = new List<IRequirement>();
            List<IRequirement> specificationList = new List<IRequirement>();
            string line;
            try
            {
                using (StreamReader sr = new StreamReader("requirement.txt"))
                {
                    while ((line = sr.ReadLine()) != "END")
                    {
                        userStoryList.Add(new UserStory().ReadRequirement(line) as UserStory);
                    }

                    while ((line = sr.ReadLine()) != "END")
                    {
                        prototypeList.Add(new Prototype().ReadRequirement(line) as Prototype);
                    }

                    while ((line = sr.ReadLine()) != "END")
                    {
                        while (!(line += sr.ReadLine()).Contains("//"))
                        {
                        }

                        line = line.Remove(line.Length - 2);
                        specificationList.Add(new Specification().ReadRequirement(line) as Specification);
                        line = string.Empty;
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine("There is " + exception.Message);
            }

            try
            {
                prototypeList.Sort();
                userStoryList.Sort();
                specificationList.Sort();
            }
            catch (Exception exception)
            {
                Console.WriteLine("There is " + exception.Message);
            }

            Console.WriteLine("Sorting...");
            foreach (UserStory item in userStoryList)
            {
                Console.WriteLine(item.WriteRequirement());
            }
            Console.WriteLine();

            foreach (Prototype item in prototypeList)
            {
                Console.WriteLine(item.WriteRequirement());
            }
            Console.WriteLine();

            foreach (Specification item in specificationList)
            {
                Console.Write(item.WriteRequirement());
            }
            Console.WriteLine();

            foreach (Specification spacific in specificationList)
            {
                foreach (UserStory userStory in userStoryList)
                {
                    if (spacific.ProductName == userStory.ProductName)
                    {
                        spacific.AddUserStory(userStory);
                    }
                }

                foreach (Prototype protot in prototypeList)
                {
                    if (spacific.ProductName == protot.ProductName)
                    {
                        spacific.AddPrototype(protot);
                    }
                }
            }

            using (StreamWriter sw = new StreamWriter("resultDateFile.txt", false, System.Text.Encoding.Default))
            {
                foreach (Specification item in specificationList)
                {
                    sw.WriteLine(item.WriteRequirement());
                }
            }

            Console.WriteLine("All done");
        }
    }
}
