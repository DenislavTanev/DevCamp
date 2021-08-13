namespace DevCamp.Web.ViewModels.Images
{
    using DevCamp.Data.Models;
    using DevCamp.Services.Mapping;

    public class ImageViewModel : IMapFrom<Image>
    {
        public byte[] Img { get; set; }
    }
}
