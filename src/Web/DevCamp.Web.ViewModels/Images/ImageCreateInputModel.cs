namespace DevCamp.Web.ViewModels.Images
{
    using Microsoft.AspNetCore.Http;

    public class ImageCreateInputModel
    {
        public string UserId { get; set; }

        public IFormFile Image { get; set; }
    }
}
