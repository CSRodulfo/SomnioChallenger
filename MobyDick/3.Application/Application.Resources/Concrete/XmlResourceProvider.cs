using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Resources.Abstract;
using Application.MainModule.Administration;

namespace Resources.Concrete
{
    public class XmlResourceProvider : BaseResourceProvider
    {
        // File path
        private static string filePath = null;

        public XmlResourceProvider() { }
        public XmlResourceProvider(string filePath)
        {
            XmlResourceProvider.filePath = filePath;

            if (!File.Exists(filePath)) throw new FileNotFoundException(string.Format("XML Resource file {0} was not found", filePath));
        }

        protected override IList<DTOResource> ReadResources()
        {

            // Parse the XML file
            return XDocument.Parse(File.ReadAllText(filePath))
                .Element("resources")
                .Elements("resource")
                .Select(e => new DTOResource
                {
                    Name = e.Attribute("name").Value,
                    Value = e.Attribute("value").Value,
                    Culture = e.Attribute("culture").Value
                }).ToList();
        }

        protected override DTOResource ReadResource(string name, string culture, int IdMenu)
        {
            // Parse the XML file
            return XDocument.Parse(File.ReadAllText(filePath))
                .Element("resources")
                .Elements("resource")
                .Where(e => e.Attribute("name").Value == name && e.Attribute("culture").Value == culture && int.Parse(e.Attribute("IdMenu").Value) == IdMenu)
                .Select(e => new DTOResource
                {
                    Name = e.Attribute("name").Value,
                    Value = e.Attribute("value").Value,
                    Culture = e.Attribute("culture").Value,
                    IdMenu = int.Parse(e.Attribute("IdMenu").Value)
                }).FirstOrDefault();
        }
    }
}
