// See https://aka.ms/new-console-template for more information
using System.Xml;
using System.Xml.Linq;
var data = XElement.Load(@"C:\Users\clikhita\Downloads\Section1.xml");
var tags = (from e in data.Descendants() select e.Name).Distinct();
foreach (var t in tags)
{
    string tag = t.ToString();
    XmlDocument xml1 = new XmlDocument();
    xml1.Load(@"C:\Users\clikhita\Downloads\Section1.xml");
    XmlDocument xml2 = new XmlDocument();
    xml2.Load(@"C:\Users\clikhita\Downloads\Section2.xml");
    XmlNodeList nodeList1 = xml1.GetElementsByTagName(tag);
    XmlNodeList nodeList2 = xml2.GetElementsByTagName(tag);
    if (nodeList2 != null)
    {
        foreach (XmlNode tag1 in nodeList1)
        {
            foreach (XmlNode tag2 in nodeList2)
            {
                if (tag1.Name == tag2.Name)
                {   
                    string s1 = tag1.InnerXml;
                    string s2 = tag2.InnerXml;
                    if (s1 != "" && s2 != "")
                    {
                        if (s1 != s2 && s1[0] != '<')
                        {
                            Console.WriteLine(tag + "     " + s1 + "     " + s2);
                            break;
                        }
                    }
                }
            }
        }
    }
}