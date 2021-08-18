namespace DevCamp.Services.Data.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IImagesService
    {
        Task CreateListAsync(List<byte[]> images, int listingId);

        Task CreateAsync(byte[] imageByte, string userId);

        Task EditAsync(string imgId, byte[] imageByte);

        IEnumerable<T> All<T>(int listingId);

        Task<T> GetByIdAsync<T>(string userId);
    }
}
