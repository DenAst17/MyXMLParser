using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyXMLParser.DataStructures
{
    struct Student
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }

        public string Faculty { get; set; }
        public string Department { get; set; }
        public string Course { get; set; }

        public List<Adress> Adresses;

        public Student(int iD, string firstName, string lastName, string patronymic, string faculty, string department, string course, List<Adress> adresses)
        {
            ID = iD;
            FirstName = firstName;
            LastName = lastName;
            Patronymic = patronymic;
            Faculty = faculty;
            Department = department;
            Course = course;
            Adresses = adresses;
        }
    }
}
