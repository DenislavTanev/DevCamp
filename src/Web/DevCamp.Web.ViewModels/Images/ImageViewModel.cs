namespace DevCamp.Web.ViewModels.Images
{
    using DevCamp.Data.Models;
    using DevCamp.Services.Mapping;

    public class ImageViewModel : IMapFrom<Image>
    {
        public string Id { get; set; }

        public byte[] Img { get; set; }

        public string UserId { get; set; }
    }
}
