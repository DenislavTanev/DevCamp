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

    public class SectorsService : ISectorsService
    {
        private readonly IRepository<Sector> sectorsRepository;

        public SectorsService(IRepository<Sector> sectorsRepository)
        {
            this.sectorsRepository = sectorsRepository;
        }

        public IEnumerable<T> GetAll<T>()
        {
            var sectors = this.sectorsRepository
                .All()
                .To<T>()
                .ToList();

            return sectors;
        }

        public async Task<T> GetById<T>(int id)
        {
            var sector = await this.sectorsRepository
                .All()
                .Where(x => x.Id == id)
                .To<T>()
                .FirstOrDefaultAsync();

            return sector;
        }
    }
}
