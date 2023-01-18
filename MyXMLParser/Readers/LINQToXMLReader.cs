using MyXMLParser.DataStructures;
using System.Xml.Linq;
using System.Xml.XPath;

namespace MyXMLParser.Readers
{
    class LINQToXMLReader : IReader
    {
        public XMLRepresentation ReadFile(string fileName)
        {
            var rep = new XMLRepresentation();
            rep.Students = new List<Student>();
            XDocument xdoc = XDocument.Load(fileName);
            var list = xdoc.XPathSelectElements("//Students//Students//Student");
            foreach (XElement el in list)
            {
                rep.Students.Add(createStudent(el));
            }

            return rep;
        }

        private Student createStudent(XElement StudentEl)
        {
            var student = new Student();
            student.Adresses = new List<Adress>();
            student.ID = Int32.Parse(StudentEl.Element("ID").Value);
            student.Name = StudentEl.Element("Name").Value;
            student.Surname = StudentEl.Element("Surname").Value;
            student.Patronymic = StudentEl.Element("Patronymic").Value;
            student.Faculty = StudentEl.Element("Faculty").Value;
            student.Course = Int32.Parse(StudentEl.Element("Course").Value);
            student.Patronymic = StudentEl.Element("Patronymic").Value;
            //student.Adresses = getAdresses(StudentEl.Element("Adresses"));
            student.Adresses = new List<Adress>();
            return student;
        }

        private List<Adress> getAdresses(XElement adressesElement)
        {
            var list = new List<Adress>();
            //foreach

            var adress = new Adress();
            

            return list;
        }

       /* private Date getDate(XmlNode dateNode)
        {
            Date date = new Date();
            foreach (XmlNode dateChildNode in dateNode)
            {
                switch (dateChildNode.Name)
                {
                    case "Day":
                        date.Day = Int32.Parse(dateChildNode.InnerText);
                        break;
                    case "Month":
                        date.Month = Int32.Parse(dateChildNode.InnerText);
                        break;
                    case "Year":
                        date.Year = Int32.Parse(dateChildNode.InnerText);
                        break;

                }
            }
            return date;
        }
       */
        public override string ToString()
        {
            return "LINQToXML";
        }
    }
}
