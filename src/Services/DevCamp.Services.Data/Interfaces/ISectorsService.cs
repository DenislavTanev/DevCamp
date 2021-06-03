namespace DevCamp.Services.Data.Interfaces
{
    using System.Collections.Generic;

    public interface ISectorsService
    {
        IEnumerable<T> GetAll<T>();
    }
}
