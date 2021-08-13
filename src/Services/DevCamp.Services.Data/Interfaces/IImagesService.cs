namespace DevCamp.Services.Data.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IImagesService
    {
        Task CreateListAsync(List<byte[]> images, int listingId);

        Task CreateAsync(byte[] imageByte, string userId);

        IEnumerable<T> All<T>(int listingId);
    }
}
