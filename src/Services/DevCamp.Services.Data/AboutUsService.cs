namespace DevCamp.Services.Data
{
    using System.Threading.Tasks;

    using DevCamp.Data.Common.Repositories;
    using DevCamp.Data.Models;
    using DevCamp.Services.Data.Interfaces;
    using DevCamp.Services.Mapping;
    using Microsoft.EntityFrameworkCore;

    public class AboutUsService : IAboutUsService
    {
        private readonly IDeletableEntityRepository<AboutUs> aboutUsRepository;

        public AboutUsService(IDeletableEntityRepository<AboutUs> aboutUsRepository)
        {
            this.aboutUsRepository = aboutUsRepository;
        }

        public async Task<T> GetInformationAsync<T>()
        {
            var aboutUsInformation = await this.aboutUsRepository
                .All()
                .To<T>()
                .FirstOrDefaultAsync();

            return aboutUsInformation;
        }
    }
}
