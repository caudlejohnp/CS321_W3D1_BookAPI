using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CS321_W3D1_BookAPI.APIModels
{
    public class BookModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int AuthorId { get; set; }

        public string Category { get; set; }

        public string Author { get; set; }

        public string Publisher { get; set; }

        public int PublisherId { get; set; }
    }
}
