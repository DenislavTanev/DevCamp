namespace DevCamp.Services.Data.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IPackagesService
    {
        Task CreateAsync(string name, double price, string packageInfo, string description);

        Task<T> GetByIdAsync<T>(int id);

        IEnumerable<T> GetAll<T>(int packageId);

        Task EditAsync(int id, string question, string answer, string userId);
    }
}
