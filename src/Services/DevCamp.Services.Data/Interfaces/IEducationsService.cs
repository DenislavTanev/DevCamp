namespace DevCamp.Services.Data.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IEducationsService
    {
        Task CreateAsync(string universityName, string universityLocation, string title, string major, int graduationYear, string userId);

        Task<T> GetByIdAsync<T>(int id);

        IEnumerable<T> GetAllByUser<T>(string userId);

        Task EditAsync(int id, string universityName, string universityLocation, string title, string major, int graduationYear, string userId);

        Task DeleteAsync(int id);
    }
}
