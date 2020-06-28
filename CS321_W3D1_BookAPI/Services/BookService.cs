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
        private readonly AppDbContext _appDbContext;

        public BookService(AppDbContext myContext)
        {
            _appDbContext = myContext;
        }
        public Book Add(Book newBook)
        {
            _appDbContext.Books.Add(newBook);
            _appDbContext.SaveChanges();
            return newBook;
        }

        public void Delete(Book book)
        {
            //Make sure book exists
            var currentBook = _appDbContext.Books.FirstOrDefault(b => b.Id == book.Id);
            if (currentBook != null)
            {
                _appDbContext.Books.Remove(book);
                _appDbContext.SaveChanges();
            }
        }

        public Book Get(int id)
        {
            return _appDbContext.Books.Include(b => b.Author).FirstOrDefault(b => b.Id == id);
        }

        public IEnumerable<Book> GetAll()
        {
            return _appDbContext.Books.Include(b => b.Author);
        }

        public IEnumerable<Book> GetBooksForAuthor(int authorId)
        {
            return _appDbContext.Books.Include(p => p.Author)
                .Include(p => p.Publisher)
                .Where(p => p.AuthorId == authorId)
                .ToList();
                
        }

        public IEnumerable<Book> GetBooksForPublisher(int publisherId)
        {
            return _appDbContext.Books.Include(p => p.Publisher)
                .Include(p => p.Author)
                .Where(p => p.PublisherId == publisherId)
                .ToList();
        }

        public Book Update(Book updatedBook)
        {
            var currentBook = _appDbContext.Books.FirstOrDefault(b => b.Id == updatedBook.Id);
            if (currentBook != null)
            {
                _appDbContext.Entry<Book>(currentBook).CurrentValues.SetValues(updatedBook);
                _appDbContext.Books.Update(updatedBook);
                _appDbContext.SaveChanges();
                return currentBook;
            }
            return null;
        }
    }
}
