namespace DevCamp.Web.ViewModels.Certifications
{
    using System.Collections.Generic;

    using DevCamp.Data.Models;
    using DevCamp.Services.Mapping;

    public class CertificationEditInputModel : IMapTo<Certification>
    {
        public int Id { get; set; }

        public string Certificate { get; set; }

        public string CertifiedFrom { get; set; }

        public int Year { get; set; }

        public string UserId { get; set; }

        public List<int> Years { get; set; }
    }
}
