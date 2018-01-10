using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = string.Empty;
            string capital = string.Empty;
            using (XmlTextReader xmlReader = new XmlTextReader(@"C:\Users\DISHLIEV\Desktop\country.xml"))
            {
                while (xmlReader.Read())
                {
                    xmlReader.WhitespaceHandling = WhitespaceHandling.None;

                    if (xmlReader.NodeType == XmlNodeType.EndElement && xmlReader.Name.Equals("countries"))
                        break;

                    if (xmlReader.NodeType == XmlNodeType.Element)
                        switch (xmlReader.Name)
                        {
                            case "country":
                                XDocument xDoc = XDocument.Parse("<root>" + xmlReader.ReadInnerXml() + "</root>");
                                name = xDoc.Root.Elements("name").FirstOrDefault().Value;
                                capital = xDoc.Root.Elements("capital").FirstOrDefault().Value;
                                break;
                        }
                }
            }
        }
    }
}
