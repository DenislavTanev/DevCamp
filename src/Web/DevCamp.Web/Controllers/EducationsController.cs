namespace DevCamp.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;

    public class EducationsController : Controller
    {
        public IActionResult AddEducation()
        {
            return this.View();
        }

        public IActionResult EditEducation()
        {
            return this.View();
        }
    }
}
