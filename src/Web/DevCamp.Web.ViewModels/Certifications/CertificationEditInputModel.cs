using DevCamp.Data.Models;
using DevCamp.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevCamp.Web.ViewModels.Certifications
{
    public class CertificationEditInputModel : IMapTo<Certification>
    {
        public int Id { get; set; }

        public string Certificate { get; set; }

        public string CertifiedFrom { get; set; }

        public int Year { get; set; }

        public string UserId { get; set; }
    }
}
