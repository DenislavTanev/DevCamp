namespace DevCamp.Services.Data.Interfaces
{
    using System;
    using System.Threading.Tasks;

    public interface IUsersService
    {
        Task<T> GetById<T>(string userId);

        Task EditNameAsync(string userId, string name);

        Task EditLocationAsync(string userId, int countryId);

        Task EditDescriptionAsync(string userId, string description);

        Task EditProfessionAsync(string userId, string profession);

        Task<T> GetProfilePic<T>(string userId);
    }
}
