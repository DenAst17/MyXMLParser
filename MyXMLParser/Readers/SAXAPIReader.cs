using MyXMLParser.DataStructures;
using System.Xml;
using System.Xml.Serialization;

namespace MyXMLParser.Readers
{
    class SAXAPIReader : IReader
    {
        public XMLRepresentation ReadFile(string filePath)
        {
            var representation = new XMLRepresentation(@"D:\Projects\C#\MyXMLParser\MyXMLParser\");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(XMLRepresentation));
            using (FileStream fs = new FileStream(@"D:\Projects\C#\MyXMLParser\MyXMLParser\XMLFileTest.xml", FileMode.OpenOrCreate))
            {
                var a = new List<Adress>();
                a.Add(new Adress(null,null,null,null,1,new Date(1, 1, 1),new Date(1, 1, 1)));
                representation.Students.Add(new Student(1, null, null, null, null, null, 1, a));
                xmlSerializer.Serialize(fs, representation);
            }
            using (FileStream fs = new FileStream(@"D:\Projects\C#\MyXMLParser\MyXMLParser\XMLFile1.xml", FileMode.OpenOrCreate))
            {
                representation = (XMLRepresentation)xmlSerializer.Deserialize(fs);
            }
            return representation;
        }

        public override string ToString()
        {
            return "SAX API";
        }

    }
}
