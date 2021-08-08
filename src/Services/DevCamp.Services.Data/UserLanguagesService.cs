using DevCamp.Data.Common.Repositories;
using DevCamp.Data.Models;
using DevCamp.Services.Data.Interfaces;
using DevCamp.Services.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<T> GetById<T>(int id)
        {
            var userLanguages = await this.userLanguageRepository
                .All()
                .Where(x => x.Id == id)
                .To<T>()
                .FirstOrDefaultAsync();

            return userLanguages;
        }
    }
}
