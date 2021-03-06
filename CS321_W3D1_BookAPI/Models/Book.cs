﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CS321_W3D1_BookAPI.Models
{
    public class Book
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int AuthorId { get; set; }

        public string Category { get; set; }

        public Author Author { get; set; }

        public Publisher Publisher { get; set; }

        public int PublisherId { get; set; }
    }
}
