namespace DevCamp.Services.Data.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using DevCamp.Web.ViewModels.Listings;

    public interface IPackagesService
    {
        Task CreateAsync(PackagesViewModel basicPackage, PackagesViewModel standartPackage, PackagesViewModel premiumPackage);

        Task<T> GetByIdAsync<T>(int id);

        IEnumerable<T> GetAll<T>(int listingId);

        Task EditAsync(PackagesViewModel basicPackage, PackagesViewModel standartPackage, PackagesViewModel premiumPackage);

        Task DeleteAsync(int id);
    }
}
