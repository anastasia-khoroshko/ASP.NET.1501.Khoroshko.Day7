using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2;

namespace UITask2Books
{
    class Program
    {
        static void Main(string[] args)
        {
            BookListService service = new BookListService(new BookRepository("book"));
            service.AddBook(new Book()
            {
                ISBN = "1525-514-D",
                Author = "W.Shakespeare",
                Title = "Hamlet",
                Copy = 12899,
                Pages = 852
            });

            service.AddBook(new Book()
            {
                ISBN = "12368-5251-X",
                Author = "M.Mitchel",
                Title = "Gone with the Wind",
                Copy = 189635,
                Pages = 785
            });
            service.AddBook(new Book() 
            { 
                ISBN="11589-258-1",
                Author="J.London",
                Title = "The House of Pride",
                Copy=5852,
                Pages=892
            });
            service.AddBook(new Book()
                {
                    ISBN = "25893-22-22-1",
                    Author = "R.Kipling",
                    Title = "Captains Courageous",
                    Copy = 60987,
                    Pages = 688
                });
            service.AddBook(new Book()
            {
                ISBN = "8974-258-2-3",
                Author = "S.King",
                Title = "The Green Mile",
                Copy = 52874,
                Pages = 784
            });
            service.Export(new ExportByWritter(),"1.xml");
            service.Export(new ExportByLinq(), "2.xml");
            service.GetsBook(delegate(Book x) { return x.Pages > 700; },"res");
            //var list = service.GetAllBooks();
            //foreach (var el in list)
            //    Console.WriteLine(Environment.NewLine+el.ToString());            
            //var res = service.GetBookByAuthor("W.Shakespeare");
            //foreach (var el in res)
            //    Console.WriteLine(Environment.NewLine + String.Format("Result search:{0}", el.ToString()));
            //var resTitle = service.GetBookByTitle("Gone");
            //foreach (var el in resTitle)
            //    Console.WriteLine(Environment.NewLine + String.Format("Result search:{0}", el.ToString()));
            //service.SortBooks();
            //Console.WriteLine("Sorting");
            //foreach (var el in list)
            //    Console.WriteLine(Environment.NewLine + el.ToString());
            Console.ReadLine();
        }
    }
}
