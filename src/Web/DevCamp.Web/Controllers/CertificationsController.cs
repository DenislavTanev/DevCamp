namespace DevCamp.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;

    public class CertificationsController : Controller
    {
        public IActionResult AddCertification()
        {
            return this.View();
        }

        public IActionResult EditCertification()
        {
            return this.View();
        }
    }
}
