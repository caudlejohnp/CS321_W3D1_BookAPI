using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CS321_W3D1_BookAPI.Data;
using CS321_W3D1_BookAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CS321_W3D1_BookAPI.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly AppDbContext _appDbContext;

        public AuthorService(AppDbContext myContext)
        {
            _appDbContext = myContext;
        }
        public Author Add(Author newAuthor)
        {
            _appDbContext.Authors.Add(newAuthor);
            _appDbContext.SaveChanges();
            return newAuthor;
        }

        public void Delete(Author author)
        {
            var currentAuthor = _appDbContext.Authors.FirstOrDefault(b => b.Id == author.Id);
            if (currentAuthor != null)
            {
                _appDbContext.Authors.Remove(author);
                _appDbContext.SaveChanges();
            }
        }

        public Author Get(int id)
        {
            return _appDbContext.Authors.Include(a => a.Books).FirstOrDefault(a => a.Id == id);
        }

        public IEnumerable<Author> GetAll()
        {
            return _appDbContext.Authors.Include(a => a.Books);
        }

        public Author Update(Author updatedAuthor)
        {
            var currentAuthor = _appDbContext.Authors.FirstOrDefault(a => a.Id == updatedAuthor.Id);
            if (currentAuthor != null)
            {
                _appDbContext.Entry<Author>(currentAuthor).CurrentValues.SetValues(updatedAuthor);
                _appDbContext.Authors.Update(updatedAuthor);
                _appDbContext.SaveChanges();
                return currentAuthor;
            }
            return null;
        }
    }
}
