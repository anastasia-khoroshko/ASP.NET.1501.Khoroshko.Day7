using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Task2
{
    public class BookListService
    {
        private IBookRepository _repository;
        private List<Book> books;
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        public BookListService(IBookRepository repository)
        {
            _repository = repository;
            books = _repository.LoadBooks().ToList();
        }
        public void AddBook(Book book)
        {
            try
            {
                foreach (Book element in books)
                {

                    if (element.Equals(book))
                    {
                        throw new ArgumentException(String.Format("Such a book: {0} {1} {2} {3} {4} already exists in the repository!", book.Author, book.Title, book.ISBN, book.Copy, book.Pages));
                    }

                }
                books.Add(book);
                _repository.SaveBooks(books);
            }
            catch (ArgumentException ex)
            {
                logger.Info(ex.Message);
                logger.Error(ex.StackTrace);
            }
        }
        public void SortBooks()
        {
            books.Sort();
            _repository.SaveBooks(books);
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return books;
        }

        public IEnumerable<Book> GetBookByAuthor(string author)
        {
            return books.Where(y => y.Author == author);
        }

        public IEnumerable<Book> GetBookByTitle(string title)
        {
            return books.Where(y => y.Title.Contains(title));
        }

        public IEnumerable<Book> GetBookByISBN(string ISBN)
        {
            return books.Where(x => x.ISBN == ISBN);
        }

        public void GetsBook(Func<Book,bool> comparer,string fileName)
        {
            if (comparer == null|| fileName.Length==0) throw new ArgumentNullException("Invalid argument");
            IEnumerable<Book> queries = books
                .Where(comparer);
            BinaryFileRepository temp = new BinaryFileRepository(fileName);
            temp.SaveBooks(queries);
        }

        public void Export(IXmlFormatExporter format, string fileName)
        {
            if (format == null || fileName.Length==0) throw new ArgumentNullException("Invalid argument");
            format.Export(books, fileName);
        }
    }
}
