namespace DevCamp.Services.Data.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public interface ICerficationsService
    {
        Task CreateAsync(string certificate, string certifiedFrom, int year, string userId);

        Task<T> GetByIdAsync<T>(int id);

        IEnumerable<T> GetAllByUser<T>(string userId);

        Task EditAsync(int id, string certificate, string certifiedFrom, int year);

        Task DeleteAsync(int id);

        List<int> GetYears();
    }
}
