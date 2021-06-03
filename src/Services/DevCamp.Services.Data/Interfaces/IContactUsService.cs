namespace DevCamp.Services.Data.Interfaces
{
    using System.Threading.Tasks;

    public interface IContactUsService
    {
        Task CreateAsync(string name, string email, string title, string content);
    }
}
