using System.Xml.Serialization;

namespace MyXMLParser.DataStructures
{
    [Serializable()]
    public struct Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }

        public string Faculty { get; set; }
        public string Department { get; set; }
        public int Course { get; set; }
        [XmlArrayItem("Adress", typeof(Adress))]
        public List<Adress> Adresses;


        public Student(int iD, string name, string surname, string patronymic, string faculty, string department, int course, List<Adress> adresses)
        {
            ID = iD;
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
            Faculty = faculty;
            Department = department;
            Course = course;
            Adresses = adresses;
        }

        public override string ToString()
        {
            string res =  ID + " " + Name + " " + Surname + " " + Patronymic + " " + Faculty + " " + Department + " " + Course + "\n";
            foreach(Adress adress in Adresses)
            {
                res += " " + adress.ToString() + "\n";
            }
            return res;
        }
    }
}
