namespace DevCamp.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;

    public class SkillsController : Controller
    {
        public IActionResult AddSkill()
        {
            return this.View();
        }

        public IActionResult EditSkill()
        {
            return this.View();
        }
    }
}
