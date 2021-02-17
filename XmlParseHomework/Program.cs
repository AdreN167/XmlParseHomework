using System;
using System.Collections.Generic;
using System.Xml;

namespace XmlParseHomework
{
    class Program
    {
        public static readonly int FIRST_ELEMENT_POSITION = 0;

        static void Main(string[] args)
        {

            //---------------1---------------
            var list = new List<Item>();

            var xmlDocumentFirst = new XmlDocument();
            xmlDocumentFirst.Load(@"https://habr.com/ru/rss/interesting/");

            var routeChannelElement = xmlDocumentFirst.GetElementsByTagName("channel")[FIRST_ELEMENT_POSITION];
            foreach (XmlElement childNode in routeChannelElement.ChildNodes)
            {
                if (childNode.Name == "item")
                {
                    var item = new Item();

                    item.Title = childNode.GetElementsByTagName("title")[FIRST_ELEMENT_POSITION].InnerText;
                    item.Link = childNode.GetElementsByTagName("link")[FIRST_ELEMENT_POSITION].InnerText;
                    item.Description = childNode.GetElementsByTagName("description")[FIRST_ELEMENT_POSITION].InnerText;
                    item.PubDate = childNode.GetElementsByTagName("pubDate")[FIRST_ELEMENT_POSITION].InnerText;

                    list.Add(item);
                }
            }

            foreach (var item in list)
            {
                Console.WriteLine($"{item.Title} - {item.Link}, {item.PubDate}");
                Console.WriteLine($"\t{item.Description}\n");
            }

            //---------------2---------------
            var students = new List<Student>
            {
                new Student
                {
                    Id = 1,
                    FirstName = "Petr",
                    SecondName = "Vorobushkin",
                    Age = 23,
                    Group = "SEP-203/2",
                    Marks = new List<int> { 5, 3, 5, 4, 5, 4, 4, 3, 4 }
                },
                new Student
                {
                    Id = 1,
                    FirstName = "Ivan",
                    SecondName = "Kolotushkin",
                    Age = 19,
                    Group = "SEB-101/1",
                    Marks = new List<int> { 5, 3, 5, 4, 5, 4, 4, 3, 4 }
                },
            };

            var xmlDocumentSecond = new XmlDocument();

            var xmlDeclaration = xmlDocumentSecond.CreateXmlDeclaration("1.0", "utf-8", string.Empty);
            xmlDocumentSecond.AppendChild(xmlDeclaration);

            var routeElement = xmlDocumentSecond.CreateElement("students");
            xmlDocumentSecond.AppendChild(routeElement);

            foreach (var student in students)
            {
                var studentElement = xmlDocumentSecond.CreateElement("student");

                studentElement.SetAttribute("id", student.Id.ToString());
                studentElement.SetAttribute("firstName", student.FirstName);
                studentElement.SetAttribute("secondName", student.SecondName);
                studentElement.SetAttribute("age", student.Age.ToString());
                studentElement.SetAttribute("group", student.Group);

                string marksAsString = string.Empty;

                foreach (var mark in student.Marks)
                {
                    marksAsString = $"{marksAsString} {mark}";
                }

                studentElement.SetAttribute("marks", marksAsString.Trim());

                routeElement.AppendChild(studentElement);
            }

            xmlDocumentSecond.Save("studentsData.xml");
        }
    }
}
 