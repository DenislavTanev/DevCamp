namespace DevCamp.Web.ViewModels.Certifications
{
    using DevCamp.Data.Models;
    using DevCamp.Services.Mapping;

    public class CertificationEditViewModel : IMapFrom<Certification>
    {
        public string Certificate { get; set; }

        public string CertifiedFrom { get; set; }

        public int Year { get; set; }

        public string UserId { get; set; }
    }
}
