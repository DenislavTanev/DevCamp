using System;
using System.Collections.Generic;
using System.Text;

namespace DevCamp.Data.Models
{
    public class PackageItem
    {
        public int Id { get; set; }

        public int PackageId { get; set; }

        public Package Package { get; set; }

        public int ItemId { get; set; }

        public Item Item { get; set; }

        public bool IsIncluded { get; set; }

        public string Content { get; set; }
    }
}
