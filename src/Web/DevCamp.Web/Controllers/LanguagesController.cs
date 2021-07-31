namespace DevCamp.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;

    public class LanguagesController : Controller
    {
        public IActionResult AddLanguage()
        {
            return this.View();
        }

        public IActionResult EditLanguage()
        {
            return this.View();
        }
    }
}
