using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class BinaryFileRepository:IBookRepository
    {
        public static string FileName { get; private set; }
        public BinaryFileRepository(string fileName) 
        {
            FileName=fileName;
        }
        public IEnumerable<Book> LoadBooks()
        {
            List<Book> books=new List<Book>();
            using (FileStream file = new FileStream(FileName, FileMode.OpenOrCreate, FileAccess.Read))
            {
                using (BinaryReader reader = new BinaryReader(file))
                {
                    while (reader.PeekChar() != -1)
                    {
                        var newBook = new Book
                        {
                            ISBN = reader.ReadString(),
                            Author = reader.ReadString(),
                            Title = reader.ReadString(),
                            Copy = reader.ReadInt32(),
                            Pages = reader.ReadInt32()
                        };
                        books.Add(newBook);
                    }
                }
            }
            return books;
        }

        public void SaveBooks(IEnumerable<Book> books)
        {
            using(FileStream file=new FileStream(FileName,FileMode.OpenOrCreate,FileAccess.Write))
            {
                using (BinaryWriter writer=new BinaryWriter(file))
                {
                    foreach(Book book in books)
                    {
                        writer.Write(book.ISBN);
                        writer.Write(book.Author);
                        writer.Write(book.Title);
                        writer.Write(book.Copy);
                        writer.Write(book.Pages);             
                    }
                }
            }
        }
    }
}
