namespace DevCamp.Services.Data.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IListingsService
    {
        Task CreateAsync(string title, string projectDetails, string userId, int categoryId, int subCategoryId);

        Task<T> GetByIdAsync<T>(int id);

        IEnumerable<T> GetAllByUser<T>(string userId);

        Task DeleteAsync(int id);

        Task EditAsync(int id, string title, string projectDetails, string userId, int categoryId, int subCategoryId);

        IEnumerable<T> GetAllByCategory<T>(int categoryId);

        IEnumerable<T> GetAllBySubCategory<T>(int subCategoryId);

        IEnumerable<T> GetAllByUserSpokenLanguage<T>(int languageId);

        IEnumerable<T> GetAllByPrice<T>(int price);

        IEnumerable<T> GetAllByUserLocation<T>(int locationId);
    }
}
