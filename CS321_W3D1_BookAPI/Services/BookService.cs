using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CS321_W3D1_BookAPI.Data;
using CS321_W3D1_BookAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CS321_W3D1_BookAPI.Services
{
    public class BookService : IBookService
    {
        private readonly BookContext _bookContext;

        public BookService(BookContext myContext)
        {
            _bookContext = myContext;
        }
        public Book Add(Book newBook)
        {
            _bookContext.Books.Add(newBook);
            _bookContext.SaveChanges();
            return newBook;
        }

        public void Delete(Book book)
        {
            //Make sure book exists
            var currentBook = _bookContext.Books.FirstOrDefault(b => b.Id == book.Id);
            if (currentBook != null)
            {
                _bookContext.Books.Remove(book);
                _bookContext.SaveChanges();
            }
        }

        public Book Get(int id)
        {
            return _bookContext.Books.FirstOrDefault(b => b.Id == id);
        }

        public IEnumerable<Book> GetAll()
        {
            return _bookContext.Books;
        }

        public Book Update(Book updatedBook)
        {
            var currentBook = _bookContext.Books.FirstOrDefault(b => b.Id == updatedBook.Id);
            if (currentBook != null)
            {
                _bookContext.Entry<Book>(currentBook).CurrentValues.SetValues(updatedBook);
                _bookContext.Books.Update(updatedBook);
                _bookContext.SaveChanges();
                return currentBook;
            }
            return null;
        }
    }
}
