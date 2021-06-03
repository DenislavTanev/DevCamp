namespace DevCamp.Services.Data.Interfaces
{
    using System.Collections.Generic;

    public interface ICountriesService
    {
        IEnumerable<T> GetAll<T>();
    }
}
