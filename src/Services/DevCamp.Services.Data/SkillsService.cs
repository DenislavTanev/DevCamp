namespace DevCamp.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using DevCamp.Data.Common.Repositories;
    using DevCamp.Data.Models;
    using DevCamp.Services.Data.Interfaces;
    using DevCamp.Services.Mapping;
    using Microsoft.EntityFrameworkCore;

    public class SkillsService : ISkillsService
    {
        private readonly IDeletableEntityRepository<UserSkill> userSkillRepository;
        private readonly IDeletableEntityRepository<ApplicationUser> usersRepository;
        private readonly IDeletableEntityRepository<Skill> skillRepository;

        public SkillsService(
            IDeletableEntityRepository<UserSkill> userSkillRepository,
            IDeletableEntityRepository<ApplicationUser> usersRepository,
            IDeletableEntityRepository<Skill> skillRepository)
        {
            this.userSkillRepository = userSkillRepository;
            this.usersRepository = usersRepository;
            this.skillRepository = skillRepository;
        }

        public async Task CreateAsync(string userId, int skillId)
        {
            var skills = new UserSkill
            {
                SkillId = skillId,
                UserId = userId,
            };

            await this.userSkillRepository.AddAsync(skills);
            await this.userSkillRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var skills = await this.userSkillRepository
                .All()
                .FirstOrDefaultAsync(x => x.Id == id);

            this.userSkillRepository.Delete(skills);
            await this.userSkillRepository.SaveChangesAsync();
        }

        public IEnumerable<T> GetAllByUser<T>(string userId)
        {
            var skills = this.userSkillRepository
                .All()
                .Where(x => x.UserId == userId)
                .To<T>()
                .ToList();

            return skills;
        }

        public IEnumerable<T> GetAllUsersBySkill<T>(int skillId)
        {
            var users = this.usersRepository
                .All()
                .Where(x => x.Skills.All(x => x.Skill.Id == skillId))
                .To<T>()
                .ToList();

            return users;
        }

        public async Task<T> GetByIdAsync<T>(int id)
        {
            var skill = await this.userSkillRepository
                .All()
                .Where(x => x.Id == id)
                .To<T>()
                .FirstOrDefaultAsync();

            return skill;
        }

        public IEnumerable<T> GetAll<T>()
        {
            var skills = this.skillRepository
                .All()
                .OrderBy(x => x.TechnologyName)
                .To<T>()
                .ToList();

            return skills;
        }
    }
}
