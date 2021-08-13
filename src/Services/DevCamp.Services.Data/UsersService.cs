namespace DevCamp.Services.Data
{
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

        public UsersService(IDeletableEntityRepository<ApplicationUser> usersRepository)
        {
            this.usersRepository = usersRepository;
        }

        public async Task<T> GetById<T>(string userId)
        {
            var user = await this.usersRepository
                .All()
                .Where(x => x.Id == userId)
                .Include(x => x.Country)
                .Include(x => x.SpokenLanguages)
                .Include(x => x.Listings)
                .Include(x => x.Skills)
                .Include(x => x.Educations)
                .Include(x => x.Certifications)
                .Include(x => x.ProfilePic)
                .To<T>()
                .FirstOrDefaultAsync();

            return user;
        }

        public async Task EditPicAsync(string userId, byte[] profilePic)
        {
            var user = await this.usersRepository
                .All()
                .FirstOrDefaultAsync(x => x.Id == userId);

            // user.ProfilePic = profilePic;
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

        public async Task<T> GetProfilePic<T>(string userId)
        {
            var image = await this.usersRepository
                .All()
                .Where(x => x.Id == userId)
                .Select(x => x.ProfilePic)
                .To<T>()
                .FirstOrDefaultAsync();

            return image;
        }
    }
}
