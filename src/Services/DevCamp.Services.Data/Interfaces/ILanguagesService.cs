namespace DevCamp.Services.Data.Interfaces
{
    using System.Collections.Generic;

    public interface ILanguagesService
    {
        IEnumerable<T> GetAll<T>();
    }
}
