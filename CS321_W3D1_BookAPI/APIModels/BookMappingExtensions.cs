using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CS321_W3D1_BookAPI.Models;

namespace CS321_W3D1_BookAPI.APIModels
{
    public static class BookMappingExtensions
    {
        public static BookModel ToApiModel(this Book book)
        {
            return new BookModel
            {
                Id = book.Id,
                Title = book.Title,
                AuthorId = book.AuthorId,
                Category = book.Category,
                PublisherId = book.PublisherId,
                Publisher = book.Publisher != null
                    ? book.Publisher.Name + ", " + book.Publisher.HeadQuartersLocation
                    : null,

                Author = book.Author != null
                    ? book.Author.LastName + ", " + book.Author.FirstName
                    : null
            };
        }

        public static Book ToDomainModel(this BookModel bookModel)
        {
            return new Book
            {
                Id = bookModel.Id,
                Title = bookModel.Title,
                AuthorId = bookModel.AuthorId,
                Category = bookModel.Category,
                PublisherId = bookModel.PublisherId,
            };
        }

        public static IEnumerable<BookModel> ToApiModels(this IEnumerable<Book> books)
        {
            return books.Select(b => b.ToApiModel());
        }

        public static IEnumerable<Book> ToDomainModel(this IEnumerable<BookModel> bookModels)
        {
            return bookModels.Select(b => b.ToDomainModel());
        }
    }
}
