using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CS321_W3D1_BookAPI.Models
{
    public class Publisher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int FoundedYear { get; set; }
        public string CountryofOrigin { get; set; }
        public string HeadQuartersLocation { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
