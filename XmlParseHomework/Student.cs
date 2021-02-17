using System;
using System.Collections.Generic;
using System.Text;

namespace XmlParseHomework
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public int Age { get; set; }
        public string Group { get; set; }
        public ICollection<int> Marks { get; set; }
    }
}
