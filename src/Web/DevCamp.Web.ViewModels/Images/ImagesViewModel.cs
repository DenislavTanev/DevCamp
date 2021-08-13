using DevCamp.Data.Models;
using DevCamp.Services.Mapping;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DevCamp.Web.ViewModels.Images
{
    public class ImagesViewModel : IMapFrom<Image>
    {
        public int ListingId { get; set; }

        public ICollection<byte[]> Img { get; set; }
    }
}
