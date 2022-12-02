using MyXMLParser.DataStructures;
using System.Xml;

namespace MyXMLParser.Readers
{
    class DOMAPIReader : IReader
    {

        public XMLRepresentation ReadFile(string filePath)
        {
            var representation = new XMLRepresentation();
            XmlDocument doc = new XmlDocument();
            doc.Load(filePath);
            XmlNodeList list = doc.SelectNodes("//Students//Students//Student");
            representation.Students = new List<Student>();
            foreach (XmlNode node in list)
            {
                    representation.Students.Add(createStudent(node));
            }
            return representation;
        }

        private Student createStudent(XmlNode node)
        {
            var student = new Student();
            student.Adresses = new List<Adress>();
            foreach(XmlNode studentNode in node)
            {
                switch (studentNode.Name)
                {
                    case "ID":
                        student.ID = Int32.Parse(studentNode.InnerText);
                        break;
                    case "Name":
                        student.Name = studentNode.InnerText;
                        break;
                    case "Surname":
                        student.Surname = studentNode.InnerText;
                        break;
                    case "Patronymic":
                        student.Patronymic = studentNode.InnerText;
                        break;
                    case "Faculty":
                        student.Faculty = studentNode.InnerText;
                        break;
                    case "Department":
                        student.Department = studentNode.InnerText;
                        break;
                    case "Course":
                        student.Course = Int32.Parse(studentNode.InnerText);
                        break;
                    case "Adresses":
                        student.Adresses = getAdresses(studentNode);
                        break;
                }
                    
            }
            return student;
        }

        private List<Adress> getAdresses(XmlNode studentNode)
        {
            var list = new List<Adress>();
            var adress = new Adress();
            foreach (XmlNode adressesNode in studentNode.ChildNodes)
            {
                foreach (XmlNode adressNode in adressesNode.ChildNodes)
                {
                    switch (adressNode.Name)
                    {
                        case "City":
                            adress.City = adressNode.InnerText;
                            break;
                        case "Street":
                            adress.Street = adressNode.InnerText;
                            break;
                        case "HouseNumber":
                            adress.HouseNumber = adressNode.InnerText;
                            break;
                        case "Flour":
                            adress.Flour = adressNode.InnerText;
                            break;
                        case "FlatNumber":
                            adress.FlatNumber = Int32.Parse(adressNode.InnerText);
                            break;
                        case "DateIn":
                            adress.DateIn = getDate(adressNode);
                            break;
                        case "DateOut":
                            adress.DateOut = getDate(adressNode);
                            break;
                    }
                }
                list.Add(adress);
            }
            
            return list;
        }

        private Date getDate(XmlNode dateNode)
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

        public override string ToString()
        {
            return "DOMAPI";
        }
    }
}
