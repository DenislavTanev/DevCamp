namespace DevCamp.Services.Data.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IListingsService
    {
        Task<int> CreateAsync(string title, string projectDetails, string userId, int categoryId, int subCategoryId);

        Task<T> GetByIdAsync<T>(int id);

        Task DeleteAsync(int id);

        Task EditTitleAsync(int id, string title);

        Task EditDetailsAsync(int id, string details);

        IEnumerable<T> GetAllByCategory<T>(int categoryId);

        IEnumerable<T> GetAllBySubCategory<T>(int subCategoryId);

        IEnumerable<T> GetAllByUserSpokenLanguage<T>(int languageId);

        IEnumerable<T> GetAllByPrice<T>(decimal price);

        IEnumerable<T> GetAllByUserLocation<T>(int locationId);

        Task SetToComplete(int id);
    }
}
