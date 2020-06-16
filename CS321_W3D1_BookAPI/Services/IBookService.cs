using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CS321_W3D1_BookAPI.Models;

namespace CS321_W3D1_BookAPI.Services
{
    public interface IBookService
    {
        //Get all
        IEnumerable<Book> GetAll();

        //Get book by id
        Book Get(int id);

        //Add Book
        Book Add(Book newBook);

        //Update Book
        Book Update(Book updatedBook);

        //Delete book
        void Delete(Book book);
    }
}
