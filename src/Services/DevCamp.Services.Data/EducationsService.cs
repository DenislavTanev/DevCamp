namespace DevCamp.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using DevCamp.Services.Data.Interfaces;

    public class EducationsService : IEducationsService
    {
        public Task CreateAsync(string universityName, string universityLocation, string title, string major, int graduationYear, string userId)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task EditAsync(int id, string universityName, string universityLocation, string title, string major, int graduationYear, string userId)
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
