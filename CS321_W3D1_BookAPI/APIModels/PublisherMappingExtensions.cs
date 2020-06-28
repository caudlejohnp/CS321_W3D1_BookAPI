using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CS321_W3D1_BookAPI.Models;

namespace CS321_W3D1_BookAPI.APIModels
{
    public static class PublisherMappingExtensions
    {
        public static PublisherModel ToApiModel(this Publisher publisher)
        {
            return new PublisherModel
            {
                Id = publisher.Id,
                Name = publisher.Name,
                FoundedYear = publisher.FoundedYear,
                HeadQuartersLocation = publisher.HeadQuartersLocation,
                CountryofOrigin = publisher.CountryofOrigin,
            };
        }

        public static Publisher ToDomainModel(this PublisherModel publisherModel)
        {
            return new Publisher
            {
                Id = publisherModel.Id,
                Name = publisherModel.Name,
                FoundedYear = publisherModel.FoundedYear,
                HeadQuartersLocation = publisherModel.HeadQuartersLocation,
                CountryofOrigin = publisherModel.CountryofOrigin,
            };
        }

        public static IEnumerable<PublisherModel> ToApiModels(this IEnumerable<Publisher> publishers)
        {
            return publishers.Select(p => p.ToApiModel());
        }

        public static IEnumerable<Publisher> ToDomainModel(this IEnumerable<PublisherModel> publisherModels)
        {
            return publisherModels.Select(p => p.ToDomainModel());
        }
    }
}
