namespace DevCamp.Services.Data.Interfaces
{
    using System.Collections.Generic;

    public interface ISkillsService
    {
        IEnumerable<T> GetAll<T>();
    }
}
