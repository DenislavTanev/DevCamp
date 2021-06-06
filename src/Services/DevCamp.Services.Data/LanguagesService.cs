namespace DevCamp.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using DevCamp.Data.Common.Repositories;
    using DevCamp.Data.Models;
    using DevCamp.Services.Data.Interfaces;
    using DevCamp.Services.Mapping;

    public class LanguagesService : ILanguagesService
    {
        private readonly IRepository<Language> languagesRepository;

        public LanguagesService(IRepository<Language> languagesRepository)
        {
            this.languagesRepository = languagesRepository;
        }

        public IEnumerable<T> GetAll<T>()
        {
            var languages = this.languagesRepository
                .All()
                .OrderBy(x => x.Name)
                .To<T>()
                .ToList();

            return languages;
        }
    }
}
