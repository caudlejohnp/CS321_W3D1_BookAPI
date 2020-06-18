using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CS321_W3D1_BookAPI.Models;

namespace CS321_W3D1_BookAPI.Services
{
    public interface IAuthorService
    {
        //Get all
        IEnumerable<Author> GetAll();

        //Get book by id
        Author Get(int id);

        //Add Book
        Author Add(Author newAuthor);

        //Update Book
        Author Update(Author updatedAuthor);

        //Delete book
        void Delete(Author author);
    }
}
