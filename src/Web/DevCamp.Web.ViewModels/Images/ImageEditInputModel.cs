namespace DevCamp.Web.ViewModels.Images
{
    using DevCamp.Data.Models;
    using DevCamp.Services.Mapping;
    using Microsoft.AspNetCore.Http;

    public class ImageEditInputModel : IMapTo<Image>
    {
        public string Id { get; set; }

        public IFormFile Image { get; set; }

        public string UserId { get; set; }
    }
}
