namespace DevCamp.Services.Data
{
    using System.Collections.Generic;

    public interface ISectorService
    {
        IEnumerable<T> GetAll<T>();
    }
}
