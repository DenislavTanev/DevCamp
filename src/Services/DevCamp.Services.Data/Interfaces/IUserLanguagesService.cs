namespace DevCamp.Services.Data.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IUserLanguagesService
    {
        Task<T> GetById<T>(int id);

        Task EditLanguageAsync(int id, int levelId);

        Task AddLanguageAsync(string userId, int languageId, int levelId);

        Task DeleteAsync(int id);
    }
}
