namespace DevCamp.Services.Data.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICategoriesService
    {
        IEnumerable<T> GetAll<T>(int sectorId);

        Task<T> GetById<T>(int id);

        int GetListingsCount(int categoryId);
    }
}
