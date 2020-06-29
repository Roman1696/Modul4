using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class CustomInitializer: DropCreateDatabaseAlways<BookStoreContext>
    {
        protected override void Seed(BookStoreContext context)
        {
            var listOfCategory = new List<Category>
            {
                new Category(){Name = "Horror"},
                new Category(){Name = "Fantasy"},
                new Category(){Name = "Adventure"}
            };

            var listOfAuthors = new List<Author>
            {
                new Author(){Name = "Sharl Pierro"},
                new Author(){Name = "Main Reed"},
                new Author(){Name = "John Tolkien "}
            };

            var bookOne = new Book { Name = "Kot v sapogah" };
            bookOne.Categories.Add(listOfCategory.Find(category => category.Name == "Adventure"));
            bookOne.Authors.Add(listOfAuthors.First());

            var bookTwo = new Book { Name = "Vsadnik bez golovy" };
            bookTwo.Categories.Add(listOfCategory.First());
            bookTwo.Authors.Add(listOfAuthors.Find(author => author.Name == "Main Reed"));

            context.Books.AddRange(new Book[] { bookOne, bookTwo });
            context.Categories.AddRange(listOfCategory);
            context.Authors.AddRange(listOfAuthors);

            context.SaveChanges();


        }
    }
}
