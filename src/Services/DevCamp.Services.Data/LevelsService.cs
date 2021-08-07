namespace DevCamp.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using DevCamp.Data.Common.Repositories;
    using DevCamp.Data.Models;
    using DevCamp.Services.Data.Interfaces;
    using DevCamp.Services.Mapping;

    public class LevelsService : ILevelsService
    {
        private readonly IRepository<Level> levelsRepository;

        public LevelsService(IRepository<Level> levelsRepository)
        {
            this.levelsRepository = levelsRepository;
        }

        public IEnumerable<T> GetAll<T>()
        {
            var levels = this.levelsRepository
                .All()
                .OrderBy(x => x.Name)
                .To<T>()
                .ToList();

            return levels;
        }
    }
}
