using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using DataAccessLayer.Models;

namespace DataAccessLayer
{
    public class BookStoreRepository
    {
        public IList<Book> GetAllBooks()
        {
            using(var context = new BookStoreContext())
            {
                return context.Books.Include(book => book.Categories).ToList();
            }
        }

        public Book GetBookById(int id)
        {
            using (var context = new BookStoreContext())
            {
                return context.Books.Include(product => product.Categories)
                    .First(p => p.Id == id);
            }
        }
        public void UpdateBook(Book book)
        {
            using (var context = new BookStoreContext())
            {
                context.Books.AddOrUpdate(book);

                context.SaveChanges();
            }
        }

        public void SaveBook(Book book)
        {
            using (var context = new BookStoreContext())
            {
                context.Books.Add(book);

                context.SaveChanges();
            }
        }

        public void RemoveBook(int id)
        {
            using (var context = new BookStoreContext())
            {
                context.Books.Remove(context.Books.First(book => book.Id == id));

                context.SaveChanges();
            }
        }

    }
}
