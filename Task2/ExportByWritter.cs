using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Task2
{
    public class ExportByWritter:IXmlFormatExporter
    {

        public void Export(IEnumerable<Book> books, string fileName)
        {
            if (fileName.Length == 0) throw new ArgumentNullException("Invalid argument");
            var xmlTextWriter = new XmlTextWriter(fileName, Encoding.UTF8)
            {
                Formatting = Formatting.Indented,
                Indentation = 2
            };
            xmlTextWriter.WriteStartDocument();
            xmlTextWriter.WriteStartElement("Books");
            foreach (var book in books)
            {
                xmlTextWriter.WriteStartElement("Book");
                xmlTextWriter.WriteElementString("ISBN", book.ISBN);
                xmlTextWriter.WriteElementString("Author", book.Author);
                xmlTextWriter.WriteElementString("Title", book.Title);
                xmlTextWriter.WriteElementString("Copy", book.Copy.ToString());
                xmlTextWriter.WriteElementString("Pages", book.Pages.ToString());
                xmlTextWriter.WriteEndElement();
            }
            xmlTextWriter.WriteEndElement();
            xmlTextWriter.WriteEndDocument();
            xmlTextWriter.Flush();
        }
    }
}
