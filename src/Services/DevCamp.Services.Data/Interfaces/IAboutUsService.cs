namespace DevCamp.Services.Data.Interfaces
{
    using System.Threading.Tasks;

    public interface IAboutUsService
    {
        Task<T> GetInformationAsync<T>();
    }
}
