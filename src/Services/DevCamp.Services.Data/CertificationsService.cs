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

    public class CertificationsService : ICerficationsService
    {
        private readonly IDeletableEntityRepository<Certification> certificationRepository;

        public CertificationsService(IDeletableEntityRepository<Certification> certificationRepository)
        {
            this.certificationRepository = certificationRepository;
        }

        public async Task CreateAsync(string certificate, string certifiedFrom, int year, string userId)
        {
            var certification = new Certification
            {
                Certificate = certificate,
                CertifiedFrom = certifiedFrom,
                Year = year,
                UserId = userId,
            };

            await this.certificationRepository.AddAsync(certification);
            await this.certificationRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var certification = await this.certificationRepository
                .All()
                .FirstOrDefaultAsync(x => x.Id == id);

            this.certificationRepository.Delete(certification);
            await this.certificationRepository.SaveChangesAsync();
        }

        public async Task EditAsync(int id, string certificate, string certifiedFrom, int year)
        {
            var certification = await this.certificationRepository
                .All()
                .FirstOrDefaultAsync(x => x.Id == id);

            certification.Certificate = certificate;
            certification.CertifiedFrom = certifiedFrom;
            certification.Year = year;

            await this.certificationRepository.SaveChangesAsync();
        }

        public IEnumerable<T> GetAllByUser<T>(string userId)
        {
            var certifications = this.certificationRepository
               .All()
               .Where(x => x.UserId == userId)
               .To<T>()
               .ToList();

            return certifications;
        }

        public async Task<T> GetByIdAsync<T>(int id)
        {
            var certification = await this.certificationRepository
                .All()
                .Where(x => x.Id == id)
                .To<T>()
                .FirstOrDefaultAsync();

            return certification;
        }

        public List<int> GetYears()
        {
            var years = new List<int>();

            for (int i = 0; i < 41; i++)
            {
                years.Add(1980 + i);
            }

            return years;
        }
    }
}
