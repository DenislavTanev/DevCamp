namespace DevCamp.Services.Data.Interfaces
{
    using System.Threading.Tasks;

    public interface IFaqService
    {
        Task CreateAsync(string question, string answer, string userId);

        Task<T> GetByIdAsync<T>(int id);

        Task EditAsync(int id, string question, string answer, string userId);
    }
}
