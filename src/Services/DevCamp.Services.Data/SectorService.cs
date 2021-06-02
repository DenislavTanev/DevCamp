namespace DevCamp.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using DevCamp.Data.Common.Repositories;
    using DevCamp.Data.Models;
    using DevCamp.Services.Data.Interfaces;
    using DevCamp.Services.Mapping;

    public class SectorService : ISectorService
    {
        private readonly IRepository<Sector> sectorsRepository;

        public SectorService(IRepository<Sector> sectorsRepository)
        {
            this.sectorsRepository = sectorsRepository;
        }

        public IEnumerable<T> GetAll<T>()
        {
            var sectors = this.sectorsRepository
                .All()
                .OrderBy(x => x.Name)
                .To<T>()
                .ToList();

            return sectors;
        }
    }
}
