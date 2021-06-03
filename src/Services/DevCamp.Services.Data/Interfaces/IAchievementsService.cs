namespace DevCamp.Services.Data.Interfaces
{
    using System.Collections.Generic;

    public interface IAchievementsService
    {
        IEnumerable<T> GetAll<T>();
    }
}
