namespace DevCamp.Services.Data.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IUserLanguagesService
    {
        IEnumerable<T> GetAllByUser<T>(string userId);

        Task<T> GetById<T>(int id);
    }
}
