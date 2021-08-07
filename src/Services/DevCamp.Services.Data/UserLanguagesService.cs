using DevCamp.Data.Common.Repositories;
using DevCamp.Data.Models;
using DevCamp.Services.Data.Interfaces;
using DevCamp.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevCamp.Services.Data
{
    public class UserLanguagesService : IUserLanguagesService
    {
        private readonly IDeletableEntityRepository<UserLanguage> userLanguageRepository;

        public UserLanguagesService(IDeletableEntityRepository<UserLanguage> userLanguageRepository)
        {
            this.userLanguageRepository = userLanguageRepository;
        }

        public IEnumerable<T> GetAllByUser<T>(string userId)
        {
            var userLanguages = this.userLanguageRepository
                .All()
                .Where(x => x.UserId == userId)
                .To<T>()
                .ToList();

            return userLanguages;
        }
    }
}
