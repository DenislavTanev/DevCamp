namespace DevCamp.Services.Data.Interfaces
{
    using System.Collections.Generic;

    public interface ICategoryService
    {
        IEnumerable<T> GetAll<T>();
    }
}
