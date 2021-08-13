namespace DevCamp.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using DevCamp.Data.Common.Repositories;
    using DevCamp.Data.Models;
    using DevCamp.Services.Data.Interfaces;
    using DevCamp.Services.Mapping;

    public class ImagesService : IImagesService
    {
        private readonly IDeletableEntityRepository<Image> imagesRepository;

        public ImagesService(IDeletableEntityRepository<Image> imagesRepository)
        {
            this.imagesRepository = imagesRepository;
        }

        public IEnumerable<T> All<T>(int listingId)
        {
            var images = this.imagesRepository
                .All()
                .Where(x => x.ListingId == listingId)
                .To<T>()
                .ToList();

            return images;
        }

        public async Task CreateListAsync(List<byte[]> images, int listingId)
        {
            foreach (var imageByte in images)
            {
                var image = new Image
                {
                    Id = Guid.NewGuid().ToString(),
                    Img = imageByte,
                    ListingId = listingId,
                };

                await this.imagesRepository.AddAsync(image);
            }

            await this.imagesRepository.SaveChangesAsync();
        }

        public async Task CreateAsync(byte[] imageByte, string userId)
        {
            var image = new Image
            {
                Id = Guid.NewGuid().ToString(),
                Img = imageByte,
                UserId = userId,
            };

            await this.imagesRepository.AddAsync(image);

            await this.imagesRepository.SaveChangesAsync();
        }
    }
}
