namespace DevCamp.Services.Data.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using DevCamp.Data.Models;

    public interface IUsersService
    {
        Task<T> GetById<T>(string userId);

        Task EditAsync(string id, string profilePic, string name, string info, int countryId, ICollection<Language> languages);
    }
}
