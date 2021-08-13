namespace DevCamp.Web.ViewModels.Images
{
    using DevCamp.Data.Models;
    using DevCamp.Services.Mapping;
    using Microsoft.AspNetCore.Http;

    public class ImageCreateInputModel : IMapTo<Image>
    {
        public string UserId { get; set; }

        public IFormFile Image { get; set; }
    }
}
