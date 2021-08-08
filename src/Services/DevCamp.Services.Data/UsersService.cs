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
                .Include(x => x.Listings)
                .Include(x => x.Skills)
                .Include(x => x.Educations)
                .Include(x => x.Certifications)
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

        public async Task EditLanguageAsync(int id, int levelId)
        {
            var language = await this.languageRepository
                .All()
                .FirstOrDefaultAsync(x => x.Id == id);

            language.LevelId = levelId;

            await this.languageRepository.SaveChangesAsync();
        }

        public async Task AddLanguageAsync(string userId, int languageId, int levelId)
        {
            var language = new UserLanguage
            {
                LanguageId = languageId,
                UserId = userId,
                LevelId = levelId,
            };

            await this.languageRepository.AddAsync(language);
            await this.languageRepository.SaveChangesAsync();
        }
    }
}
