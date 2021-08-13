using DevCamp.Data.Models;
using DevCamp.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevCamp.Web.ViewModels.Images
{
    public class ImageViewModel : IMapFrom<Image>
    {
        public string UserId { get; set; }

        public byte[] Img { get; set; }
    }
}
