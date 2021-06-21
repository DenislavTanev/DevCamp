namespace DevCamp.Services.Data
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using DevCamp.Data.Common.Repositories;
    using DevCamp.Data.Models;
    using DevCamp.Services.Data.Interfaces;
    using DevCamp.Services.Mapping;
    using Microsoft.EntityFrameworkCore;

    public class UsersService : IUsersService
    {
        private readonly IDeletableEntityRepository<ApplicationUser> usersRepository;
        private readonly IDeletableEntityRepository<UserLanguage> languageRepository;

        public UsersService(IDeletableEntityRepository<ApplicationUser> usersRepository, IDeletableEntityRepository<UserLanguage> languageRepository)
        {
            this.usersRepository = usersRepository;
            this.languageRepository = languageRepository;
        }

        public async Task<T> GetById<T>(string userId)
        {
            var user = await this.usersRepository
                .All()
                .Where(x => x.Id == userId)
                .Include(x => x.SpokenLanguages)
                .To<T>()
                .FirstOrDefaultAsync();

            return user;
        }

        public async Task EditPicAsync(string userId, byte[] profilePic)
        {
            var user = await this.usersRepository
                .All()
                .FirstOrDefaultAsync(x => x.Id == userId);

            user.ProfilePic = profilePic;

            await this.usersRepository.SaveChangesAsync();
        }

        public async Task EditNameAsync(string userId, string name)
        {
            var user = await this.usersRepository
                .All()
                .FirstOrDefaultAsync(x => x.Id == userId);

            user.Name = name;

            await this.usersRepository.SaveChangesAsync();
        }

        public async Task EditResponseTimeAsync(string userId, TimeSpan responseTime)
        {
            var user = await this.usersRepository
                .All()
                .FirstOrDefaultAsync(x => x.Id == userId);

            user.ResponseTime = responseTime;

            await this.usersRepository.SaveChangesAsync();
        }

        public async Task EditLocationAsync(string userId, int countryId)
        {
            var user = await this.usersRepository
                .All()
                .FirstOrDefaultAsync(x => x.Id == userId);

            user.CountryId = countryId;

            await this.usersRepository.SaveChangesAsync();
        }

        public async Task EditDescriptionAsync(string userId, string description)
        {
            var user = await this.usersRepository
                .All()
                .FirstOrDefaultAsync(x => x.Id == userId);

            user.Information = description;

            await this.usersRepository.SaveChangesAsync();
        }

        public async Task EditProfessionAsync(string userId, string profession)
        {
            var user = await this.usersRepository
                .All()
                .FirstOrDefaultAsync(x => x.Id == userId);

            user.Profession = profession;

            await this.usersRepository.SaveChangesAsync();
        }

        public async Task EditLanguageAsync(int id, string level)
        {
            var language = await this.languageRepository
                .All()
                .FirstOrDefaultAsync(x => x.Id == id);

            language.Level = level;

            await this.languageRepository.SaveChangesAsync();
        }

        public async Task AddLanguageAsync(string userId, int languageId, string level)
        {
            var language = new UserLanguage
            {
                LanguageId = languageId,
                UserId = userId,
                Level = level,
            };

            await this.languageRepository.AddAsync(language);
            await this.languageRepository.SaveChangesAsync();
        }
    }
}
