using DevCamp.Services.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DevCamp.Services.Data
{
    public class CertificationsService : ICerficationsService
    {
        public Task CreateAsync(string certificate, string certifiedFrom, int year, string userId)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task EditAsync(int id, string certificate, string certifiedFrom, int year)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAllByUser<T>(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetByIdAsync<T>(int id)
        {
            throw new NotImplementedException();
        }
    }
}
