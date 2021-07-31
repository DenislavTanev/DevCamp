﻿namespace DevCamp.Services.Data.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ISkillsService
    {
        Task CreateAsync(string technologyName, string level, string userId, int skillId);

        Task<T> GetByIdAsync<T>(int id);

        IEnumerable<T> GetAllByUser<T>(string userId);

        IEnumerable<T> GetAllUsersBySkill<T>(int skillId);

        Task EditAsync(int id, string level);

        Task DeleteAsync(int id);
    }
}
