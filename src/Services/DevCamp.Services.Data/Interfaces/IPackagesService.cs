﻿namespace DevCamp.Services.Data.Interfaces
{
    using DevCamp.Web.ViewModels.Listings;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IPackagesService
    {
        Task CreateAsync(List<PackagesViewModel> packages);

        Task<T> GetByIdAsync<T>(int id);

        IEnumerable<T> GetAll<T>(int listingId);

        Task EditAsync(int id, string name, double price, string description, int listingId, string revisions, string deliveryTime);

        Task DeleteAsync(int id);
    }
}
