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

    public class FaqService : IFaqService
    {
        private readonly IDeletableEntityRepository<FrequentlyAskedQuestion> faqRepository;

        public FaqService(IDeletableEntityRepository<FrequentlyAskedQuestion> faqRepository)
        {
            this.faqRepository = faqRepository;
        }

        public async Task CreateAsync(string question, string answer, int listingId)
        {
            var faq = new FrequentlyAskedQuestion
            {
                Question = question,
                Answer = answer,
                ListingId = listingId,
            };

            await this.faqRepository.AddAsync(faq);
            await this.faqRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int faqId)
        {
            var faq = await this.faqRepository
                .All()
                .FirstOrDefaultAsync(x => x.Id == faqId);

            this.faqRepository.Delete(faq);

            await this.faqRepository.SaveChangesAsync();
        }

        public async Task EditAsync(int id, string question, string answer)
        {
            var faq = await this.faqRepository
                .All()
                .FirstOrDefaultAsync(x => x.Id == id);

            faq.Question = question;
            faq.Answer = answer;

            await this.faqRepository.SaveChangesAsync();
        }

        public async Task<T> GetByIdAsync<T>(int id)
        {
            var faq = await this.faqRepository
                .All()
                .Where(x => x.Id == id)
                .To<T>()
                .FirstOrDefaultAsync();

            return faq;
        }
    }
}
