using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CS321_W3D1_BookAPI.Models;

namespace CS321_W3D1_BookAPI.Services
{
    public interface IPublisherService
    {
        //Get all
        IEnumerable<Publisher> GetAll();

        //Get book by id
        Publisher Get(int id);

        //Add Book
        Publisher Add(Publisher newPublisher);

        //Update Book
        Publisher Update(Publisher updatedPublisher);

        //Delete book
        void Delete(Publisher publisher);
    }
}
