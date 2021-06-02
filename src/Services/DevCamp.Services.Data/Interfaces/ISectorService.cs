namespace DevCamp.Services.Data.Interfaces
{
    using System.Collections.Generic;

    public interface ISectorService
    {
        IEnumerable<T> GetAll<T>();
    }
}
