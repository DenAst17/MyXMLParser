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
