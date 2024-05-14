using System;
using System.Text.Json;
using System.Xml;

namespace JsonToXmlConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            string json = "{\"name\": \"Денис\", \"lastname\": \"Чорноног\", \"age\": 35, \"city\": \"Москва\"}";

            using (JsonDocument doc = JsonDocument.Parse(json))
            {
                using (XmlWriter writer = XmlWriter.Create(Console.Out))
                {
                    writer.WriteStartDocument();
                    writer.WriteStartElement("root");

                    foreach (JsonProperty property in doc.RootElement.EnumerateObject())
                    {
                        writer.WriteStartElement(property.Name);
                        writer.WriteString(property.Value.ToString());
                        writer.WriteEndElement();
                    }

                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                }
            }
        }
    }
}