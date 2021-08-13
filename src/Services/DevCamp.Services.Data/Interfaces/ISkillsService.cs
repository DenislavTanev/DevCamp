namespace DevCamp.Services.Data.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ISkillsService
    {
        Task CreateAsync(string userId, int skillId);

        Task DeleteAsync(int id);

        IEnumerable<T> GetAll<T>();
    }
}
