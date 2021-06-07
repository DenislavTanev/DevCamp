namespace DevCamp.Services.Data.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IFaqService
    {
        Task CreateAsync(string question, string answer, int listingId);

        Task<T> GetByIdAsync<T>(int id);

        IEnumerable<T> GetAll<T>(int listingId);

        Task EditAsync(int id, string question, string answer);

        Task DeleteAsync(int faqId);
    }
}
