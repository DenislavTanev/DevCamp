namespace DevCamp.Web.ViewModels.FAQs
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using DevCamp.Data.Models;
    using DevCamp.Services.Mapping;

    public class FaqEditViewModel : IMapFrom<FrequentlyAskedQuestion>
    {
        public int Id { get; set; }

        public string Question { get; set; }

        public string Answer { get; set; }

        public int ListingId { get; set; }
    }
}
