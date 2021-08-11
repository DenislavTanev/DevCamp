namespace DevCamp.Services.Data.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ISkillsService
    {
        Task CreateAsync(string userId, int skillId);

        Task<T> GetByIdAsync<T>(int id);

        IEnumerable<T> GetAllByUser<T>(string userId);

        IEnumerable<T> GetAllUsersBySkill<T>(int skillId);

        Task DeleteAsync(int id);

        IEnumerable<T> GetAll<T>();
    }
}
