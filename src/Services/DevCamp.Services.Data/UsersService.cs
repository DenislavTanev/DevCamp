namespace DevCamp.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using DevCamp.Data.Common.Repositories;
    using DevCamp.Data.Models;
    using DevCamp.Services.Data.Interfaces;
    using DevCamp.Services.Mapping;
    using Microsoft.EntityFrameworkCore;

    public class UsersService : IUsersService
    {
        private readonly IDeletableEntityRepository<ApplicationUser> usersRepository;

        public UsersService(IDeletableEntityRepository<ApplicationUser> usersRepository)
        {
            this.usersRepository = usersRepository;
        }

        public async Task EditAsync(string userId, string profilePic, string name, string info, int countryId, ICollection<Language> languages)
        {
            var user = await this.usersRepository
                .All()
                .FirstOrDefaultAsync(x => x.Id == userId);

            user.ProfilePic = profilePic;
            user.Name = name;
            user.Information = info;
            user.CountryId = countryId;
            user.SpokenLanguages = languages;

            await this.usersRepository.SaveChangesAsync();
        }

        public async Task<T> GetById<T>(string userId)
        {
            var user = await this.usersRepository
                .All()
                .Where(x => x.Id == userId)
                .To<T>()
                .FirstOrDefaultAsync();

            return user;
        }
    }
}
