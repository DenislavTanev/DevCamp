namespace DevCamp.Services.Data.Interfaces
{
    using System.Collections.Generic;

    public interface IUserLanguagesService
    {
        IEnumerable<T> GetAllByUser<T>(string userId);
    }
}
