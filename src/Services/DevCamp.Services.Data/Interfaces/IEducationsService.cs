namespace DevCamp.Services.Data.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IEducationsService
    {
        Task CreateAsync(string universityName, string universityLocation, string title, string major, int graduationYear, string userId);

        Task<T> GetByIdAsync<T>(int id);

        Task EditAsync(int id, string universityName, string universityLocation, string title, string major, int graduationYear);

        Task DeleteAsync(int id);

        List<int> GetYears();

        List<string> GetTitle();
    }
}
