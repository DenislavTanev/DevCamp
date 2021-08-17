namespace DevCamp.Services.Data.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ISubCategoriesService
    {
        IEnumerable<T> GetAll<T>(int categoryId);

        Task<T> GetById<T>(int id);

        int GetListingsCount(int subCategoryId);
    }
}
