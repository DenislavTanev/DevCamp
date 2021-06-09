namespace DevCamp.Web.ViewModels.FAQs
{
    using DevCamp.Data.Models;
    using DevCamp.Services.Mapping;

    public class FaqViewModel : IMapFrom<FrequentlyAskedQuestion>
    {
        public int Id { get; set; }

        public string Question { get; set; }

        public string Answer { get; set; }
    }
}
