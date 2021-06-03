namespace DevCamp.Services.Data.Interfaces
{
    using System.Collections.Generic;

    public interface IItemsService
    {
        IEnumerable<T> GetAll<T>();
    }
}
