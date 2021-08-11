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

    public class EducationsService : IEducationsService
    {
        private readonly IDeletableEntityRepository<Education> educationRepository;

        public EducationsService(IDeletableEntityRepository<Education> educationRepository)
        {
            this.educationRepository = educationRepository;
        }

        public async Task CreateAsync(string universityName, string universityLocation, string title, string major, int graduationYear, string userId)
        {
            var education = new Education
            {
                UniversityName = universityName,
                UniversityLocation = universityLocation,
                Title = title,
                Major = major,
                GraduationYear = graduationYear,
                UserId = userId,
            };

            await this.educationRepository.AddAsync(education);
            await this.educationRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var education = await this.educationRepository
                .All()
                .FirstOrDefaultAsync(x => x.Id == id);

            this.educationRepository.Delete(education);
            await this.educationRepository.SaveChangesAsync();
        }

        public async Task EditAsync(int id, string universityName, string universityLocation, string title, string major, int graduationYear)
        {
            var education = await this.educationRepository
               .All()
               .FirstOrDefaultAsync(x => x.Id == id);

            education.UniversityName = universityName;
            education.UniversityLocation = universityLocation;
            education.Title = title;
            education.Major = major;
            education.GraduationYear = graduationYear;

            await this.educationRepository.SaveChangesAsync();
        }

        public IEnumerable<T> GetAllByUser<T>(string userId)
        {
            var educations = this.educationRepository
                .All()
                .Where(x => x.UserId == userId)
                .To<T>()
                .ToList();

            return educations;
        }

        public async Task<T> GetByIdAsync<T>(int id)
        {
            var education = await this.educationRepository
                .All()
                .Where(x => x.Id == id)
                .To<T>()
                .FirstOrDefaultAsync();

            return education;
        }

        public List<string> GetTitle()
        {
            var titles = new List<string>()
            {
                "Associate",
                "B.A.",
                "BArch",
                "BM",
                "BFA",
                "B.Sc.",
                "M.A.",
                "M.B.A.",
                "MFA",
                "M.Sc.",
                "J.D.",
                "M.D.",
                "Ph.D",
                "LLB",
                "LLM",
                "Others",
            };

            return titles;
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
