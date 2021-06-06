namespace DevCamp.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using DevCamp.Data.Common.Repositories;
    using DevCamp.Data.Models;
    using DevCamp.Services.Data.Interfaces;
    using DevCamp.Services.Mapping;

    public class CountriesService : ICountriesService
    {
        private readonly IRepository<Country> countriesRepository;

        public CountriesService(IRepository<Country> countriesRepository)
        {
            this.countriesRepository = countriesRepository;
        }

        public IEnumerable<T> GetAll<T>()
        {
            var countries = this.countriesRepository
                .All()
                .OrderBy(x => x.Name)
                .To<T>()
                .ToList();

            return countries;
        }
    }
}
