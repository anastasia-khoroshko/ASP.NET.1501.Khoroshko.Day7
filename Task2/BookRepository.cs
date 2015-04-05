using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using Task2;

namespace Task2
{
    [Serializable]
    public class BookRepository:IBookRepository,ISerializable
    {
        private string FileName{get;set;}
        private List<Book> books;
        public BookRepository(string fileName)
        {
            FileName=fileName;
        }

        protected BookRepository(SerializationInfo si, StreamingContext context)
        {
            Book[] a = (Book[])si.GetValue("Books", typeof(Book[]));
            books = new List<Book>(a);
        }
        public IEnumerable<Book> LoadBooks()
        {
            books = new List<Book>();
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream file = new FileStream(FileName, FileMode.OpenOrCreate))
            {
                try
                {
                    Book[] newBook = (Book[])formatter.Deserialize(file);
                    books=newBook.ToList();
                }
                catch (SerializationException ex)
                {
                    books = new List<Book>();
                }
            }
            
            return books;
        }

        public void SaveBooks(IEnumerable<Book> books)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream file = new FileStream(FileName, FileMode.OpenOrCreate, FileAccess.Write))
            {                
                    formatter.Serialize(file, books.ToArray());
            }
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Books",books.ToArray());
        }

    }
}
