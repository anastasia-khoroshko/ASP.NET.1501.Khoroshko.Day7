using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Task2
{
    public class ExportByLinq : IXmlFormatExporter
    {

        public void Export(IEnumerable<Book> books, string fileName)
        {
            if (fileName.Length == 0) throw new ArgumentNullException("Invalid argument");
            var xDoc = new XDocument(
            new XDeclaration("1.0", "utf-8", null));
            var element = new XElement("Books",
                from book in books
                select new XElement("Book",
                new XElement("ISBN", book.ISBN),
                new XElement("Author", book.Author),
                new XElement("Title", book.Title),
                new XElement("Copy", book.Copy),
                new XElement("Pages", book.Pages)
                ));
            xDoc.Add(element);
            xDoc.Save(fileName);
        }
    }
}
