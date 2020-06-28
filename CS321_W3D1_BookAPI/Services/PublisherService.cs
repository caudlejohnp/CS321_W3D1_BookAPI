using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CS321_W3D1_BookAPI.Data;
using CS321_W3D1_BookAPI.Models;

namespace CS321_W3D1_BookAPI.Services
{
    public class PublisherService : IPublisherService
    {
        private readonly AppDbContext _appDbContext;

        public PublisherService(AppDbContext myContext)
        {
            _appDbContext = myContext;
        }
        public Publisher Add(Publisher newPublisher)
        {
            _appDbContext.Publishers.Add(newPublisher);
            _appDbContext.SaveChanges();
            return newPublisher;
        }

        public void Delete(Publisher publisher)
        {
            //Make sure book exists
            var currentPublisher = _appDbContext.Publishers.FirstOrDefault(p => p.Id == publisher.Id);
            if (currentPublisher != null)
            {
                _appDbContext.Publishers.Remove(publisher);
                _appDbContext.SaveChanges();
            }
        }

        public Publisher Get(int id)
        {
            return _appDbContext.Publishers.FirstOrDefault(b => b.Id == id);
        }

        public IEnumerable<Publisher> GetAll()
        {
            return _appDbContext.Publishers;
        }

        public Publisher Update(Publisher updatedPublisher)
        {
            var currentPublisher = _appDbContext.Publishers.FirstOrDefault(p => p.Id == updatedPublisher.Id);
            if (currentPublisher != null)
            {
                _appDbContext.Entry<Publisher>(currentPublisher).CurrentValues.SetValues(updatedPublisher);
                _appDbContext.Publishers.Update(updatedPublisher);
                _appDbContext.SaveChanges();
                return currentPublisher;
            }
            return null;
        }
    }
}
