using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task1Platform;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestCloneSpecificationMethod()
        {
            string expected = "Text for testing specification1.";
            Specification specification1 = new Specification("Text for testing specification1.");
            Specification specification2 = (Specification)specification1.Clone();
            specification1.Text = "!!!FirstSpecificationText";
            string actual = specification2.Text;

            Assert.AreEqual(expected, actual, "Specification not cloned correctly");
        }

        [TestMethod]
        public void TestCloneUserStoryMethod()
        {
            string expected = "Text fot texting User Story1";
            UserStory userStory1 = new UserStory("Product name 1 for UserStory1", "User story 1 for testing specification 1", "Text fot texting User Story1");
            UserStory userStory2 = (UserStory)userStory1.Clone();
            userStory1.TextOfUserStory = "!!!FirstSpecificationUserStoryText";
            string actual = userStory2.TextOfUserStory;

            Assert.AreEqual(expected, actual, "UserStory not cloned correctly");
        }
        [TestMethod]
        public void TestClonePrototypeMethod()
        {
            string expected = "Prototype.doc";
            Prototype prototype1 = new Prototype("Product name 1 for Prototype1", "Prototype.doc", "10KB");
            Prototype prototype2 = (Prototype)prototype1.Clone();
            prototype1.FileName = "PrototypeNameDocument.doc";
            string actual = prototype2.FileName;

            Assert.AreEqual(expected, actual, "Prototype not cloned correctly");
        }
        [TestMethod]
        public void TestCompareToPrototypeMethod()
        {
            double expected = 0;
            Prototype prototype1 = new Prototype("Name", "Name.doc", "10KB");
            Prototype prototype2 = new Prototype("Name", "Name.doc", "10KB");
            double actual = prototype1.CompareTo(prototype2);
            Assert.AreEqual(expected, actual, 0.001, "Prototype not compared correctly");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestCompareToPrototypeMethod_WhenPrototypeUncorrect()
        {
            Prototype prototype = new Prototype("Name", "Name.doc", "10KB");
            UserStory userStory = new UserStory("NameProduct", "USerStoryName", "Text");
            prototype.CompareTo(userStory);
        }

        [TestMethod]
        public void TestCompareToUserStoryMethod()
        {
            double expected = 0;
            UserStory userStory1 = new UserStory("Name", "NameUS", "Text");
            UserStory userStory2 = new UserStory("Name", "NameUS", "Text");
            double actual = userStory1.CompareTo(userStory2);
            Assert.AreEqual(expected, actual, 0.001, "UserStory not compared correctly");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestCompareToUserStoryMethod_WhenPrototypeUncorrect()
        {
            Prototype prototype = new Prototype("Name", "Name.doc", "10KB");
            UserStory userStory = new UserStory("NameProduct", "USerStoryName", "Text");
            userStory.CompareTo(prototype);
        }

        [TestMethod]
        public void TestCompareToSpecificationMethod()
        {
            double expected = 0;
            Specification specificstion1 = new Specification("Text");
            Specification specification2 = new Specification("Text");
            double actual = specificstion1.CompareTo(specification2);
            Assert.AreEqual(expected, actual, 0.001, "Specification not compared correctly");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestCompareToSpecificationMethod_WhenSpecificationUncorrect()
        {
            Specification specification = new Specification("Text");
            UserStory userStory = new UserStory("NameProduct", "USerStoryName", "Text");
            specification.CompareTo(userStory);
        }

        [TestMethod]
        public void TestAddUserStoryMethod()
        {
            string expected = "Name";
            UserStory userStory1 = new UserStory("Name", "NameUS", "Text");
            Specification specification = new Specification("Text");
            specification.AddUserStory(userStory1);
            string actual = specification.UserStoryList[0].ProductName;
            Assert.AreEqual(expected, actual, "Specification not add user story correctly");
        }

        [TestMethod]
        public void TestAddPrototypeMethod()
        {
            string expected = "Name";
            Prototype prototype1 = new Prototype("Name", "Prototype.doc", "10KB");
            Specification specification = new Specification("Text");
            specification.AddPrototype(prototype1);
            string actual = specification.PrototypeList[0].ProductName;
            Assert.AreEqual(expected, actual, "Specification not add prototype correctly");
        }

        [TestMethod]
        public void TestReadRequirementPrototypeMethod()
        {
            string expected = "Name";
            Prototype prototype1 = new Prototype();
            prototype1 = (Prototype)prototype1.ReadRequirement("Name Prototype.doc 10KB");
            string actual = prototype1.ProductName;
            Assert.AreEqual(expected, actual, "Prototype not read requirement correctly");
        }

        [TestMethod]
        public void TestReadRequirementUserStoryMethod()
        {
            string expected = "Name";
            UserStory userStory1 = new UserStory();
            userStory1 = (UserStory)userStory1.ReadRequirement("Name USerStory Text");
            string actual = userStory1.ProductName;
            Assert.AreEqual(expected, actual, "User story not read requirement correctly");
        }

        [TestMethod]
        public void TestReadRequirementSpecificationMethod()
        {
            string expected = "Text";
            Specification specification = new Specification();
            specification = (Specification)specification.ReadRequirement("Text");
            string actual = specification.Text;
            Assert.AreEqual(expected, actual, "Specification not read requirement correctly");
        }

        [TestMethod]
        public void TestWriteRequirementPrototypeMethod()
        {
            string expected = "Name Prototype.doc 10KB";
            Prototype prototype1 = new Prototype("Name", "Prototype.doc", "10KB");
            string actual = prototype1.WriteRequirement();
            Assert.AreEqual(expected, actual, "Prototype not write requirement correctly");
        }

        [TestMethod]
        public void TestWriteRequirementUserStoryMethod()
        {
            string expected = "NameProduct USerStoryName Text";
            UserStory userStory = new UserStory("NameProduct", "USerStoryName", "Text");
            string actual = userStory.WriteRequirement();
            Assert.AreEqual(expected, actual, "User story not write requirement correctly");
        }

        [TestMethod]
        public void TestWriteRequirementSpecificationMethod()
        {
            string expected = "Text\n";
            Specification specification = new Specification("Text");
            string actual = specification.WriteRequirement();
            Assert.AreEqual(expected, actual, "Specification not read requirement correctly");
        }
    }

}
