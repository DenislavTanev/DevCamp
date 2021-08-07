namespace DevCamp.Services.Data.Interfaces
{
    using System.Collections.Generic;

    public interface ILevelsService
    {
        IEnumerable<T> GetAll<T>();
    }
}
