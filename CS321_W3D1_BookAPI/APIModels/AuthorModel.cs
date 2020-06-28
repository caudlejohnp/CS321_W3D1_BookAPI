using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CS321_W3D1_BookAPI.APIModels
{
    public class AuthorModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime Birthday { get; set; }
        public ICollection<BookModel> Books { get; set; }
    }
}
