namespace DevCamp.Services.Data.Interfaces
{
    using System.Collections.Generic;

    public interface ICategoriesService
    {
        IEnumerable<T> GetAll<T>(int sectorId);

        int GetListingsCount();
    }
}
