namespace DevCamp.Web.ViewModels.Images
{
    using System.Collections.Generic;

    using DevCamp.Data.Models;
    using DevCamp.Services.Mapping;
    using Microsoft.AspNetCore.Http;

    public class ImagesListCreateInputModel : IMapTo<Image>
    {
        public int ListingId { get; set; }

        public List<IFormFile> Images { get; set; }
    }
}
