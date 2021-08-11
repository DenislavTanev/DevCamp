namespace DevCamp.Web.ViewModels.Certifications
{
    using DevCamp.Data.Models;
    using DevCamp.Services.Mapping;

    public class CertificationViewModel : IMapFrom<Certification>
    {
        public int Id { get; set; }

        public string Certificate { get; set; }

        public string CertifiedFrom { get; set; }

        public int Year { get; set; }
    }
}
