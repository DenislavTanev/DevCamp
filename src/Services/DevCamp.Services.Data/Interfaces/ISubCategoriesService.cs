namespace DevCamp.Services.Data.Interfaces
{
    using System.Collections.Generic;

    public interface ISubCategoriesService
    {
        IEnumerable<T> GetAll<T>(int categoryId);

        int GetListingsCount(int subCategoryId);
    }
}
