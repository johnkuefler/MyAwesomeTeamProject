using System;
using System.Collections.Generic;
using System.Text;

namespace MyAwesomeProject
{
    public class BookService
    {
        public List<Book> FindBooks(string name)
        {
            return new List<Book>
            {
                new Book
                {
                    Name = "Harry Potter and the Sorcerers Stone",
                    ISBN = "10-232424",
                    Image = "harrypotter.jpg"
                },
                new Book
                {
                    Name = "Harry Potter and the Chamber of Secrets",
                    ISBN = "11-1212222",
                    Image = "harrypotter.jpg"
                },
                new Book
                {
                    Name = "Harry Potter and the Prisoner of Azkaban",
                    ISBN = "14-7967855",
                    Image = "harrypotter.jpg"
                }
            };
        }
    }


    public class Book
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public string ISBN { get; set; }
    }
}
