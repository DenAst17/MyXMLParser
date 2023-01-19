using MyXMLParser.DataStructures;
using System.Xml;
using System.Xml.Serialization;

namespace MyXMLParser.Readers
{
    class SAXAPIReader : IReader
    {
        public XMLRepresentation ReadFile(string filePath)
        {
            var representation = new XMLRepresentation(filePath);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(XMLRepresentation));
            using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
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
