using System.Xml;
using System.Xml.Serialization;

namespace MyXMLParser.DataStructures
{
    [XmlRoot("Students")]
    [Serializable()]
    public struct XMLRepresentation
    {
        [XmlIgnore]
        public string filePath;
        [XmlArrayItem("Student", typeof(Student))]
        public List<Student> Students;

        public XMLRepresentation(string filePath)
        {
            this.filePath = filePath;
            Students = new List<Student>();
        }

        public override string ToString()
        {
            string result = "";
            foreach (Student student in Students)
            {
                result += student.ToString();
                result += "\n";
            }
            return result;
        }
    }
}
