namespace DevCamp.Services.Data.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ISectorsService
    {
        IEnumerable<T> GetAll<T>();

        Task<T> GetById<T>(int id);
    }
}
