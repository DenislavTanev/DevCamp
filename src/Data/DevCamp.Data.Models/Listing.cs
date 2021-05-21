namespace DevCamp.Data.Models
{
    using System.Collections.Generic;

    using DevCamp.Data.Common.Models;

    public class Listing : BaseDeletableModel<string>
    {
        public string Title { get; set; }

        public ICollection<byte[]> Images { get; set; }

        public string ProjectDetails { get; set; }

        public string ServiceTiers { get; set; }//

        //frequently asked questions

        //profile info
    }
}
