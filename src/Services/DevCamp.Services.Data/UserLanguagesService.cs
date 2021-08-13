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

    public class UserLanguagesService : IUserLanguagesService
    {
        private readonly IDeletableEntityRepository<UserLanguage> userLanguageRepository;

        public UserLanguagesService(IDeletableEntityRepository<UserLanguage> userLanguageRepository)
        {
            this.userLanguageRepository = userLanguageRepository;
        }

        public async Task EditLanguageAsync(int id, int levelId)
        {
            var language = await this.userLanguageRepository
                .All()
                .FirstOrDefaultAsync(x => x.Id == id);

            language.LevelId = levelId;

            await this.userLanguageRepository.SaveChangesAsync();
        }

        public async Task AddLanguageAsync(string userId, int languageId, int levelId)
        {
            var language = new UserLanguage
            {
                LanguageId = languageId,
                UserId = userId,
                LevelId = levelId,
            };

            await this.userLanguageRepository.AddAsync(language);
            await this.userLanguageRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var language = await this.userLanguageRepository
                .All()
                .FirstOrDefaultAsync(x => x.Id == id);

            this.userLanguageRepository.Delete(language);
            await this.userLanguageRepository.SaveChangesAsync();
        }

        public async Task<T> GetById<T>(int id)
        {
            var userLanguages = await this.userLanguageRepository
                .All()
                .Where(x => x.Id == id)
                .To<T>()
                .FirstOrDefaultAsync();

            return userLanguages;
        }
    }
}
