using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CS321_W3D1_BookAPI.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CS321_W3D1_BookAPI.APIModels
{
    public static class AuthorMappingExtensions
    {
        public static AuthorModel ToApiModel(this Author author)
        {
            return new AuthorModel
            {
                Id = author.Id,
                Birthday = author.Birthday,
                FirstName = author.FirstName,
                LastName = author.LastName,
            };
        }

        public static Author ToDomainModel(this AuthorModel authorModel)
        {
            return new Author
            {
                Id = authorModel.Id,
                Birthday = authorModel.Birthday,
                FirstName = authorModel.FirstName,
                LastName = authorModel.LastName,
            };
        }

        public static IEnumerable<AuthorModel> ToApiModels(this IEnumerable<Author> authors)
        {
            return authors.Select(a => a.ToApiModel());
        }

        public static IEnumerable<Author> ToDomainModel(this IEnumerable<AuthorModel> authorModels)
        {
            return authorModels.Select(a => a.ToDomainModel());
        }
    }
}
