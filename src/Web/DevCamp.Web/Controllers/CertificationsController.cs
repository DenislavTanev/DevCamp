namespace DevCamp.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using DevCamp.Data.Models;
    using DevCamp.Services.Data.Interfaces;
    using DevCamp.Web.ViewModels.Certifications;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class CertificationsController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IUsersService usersService;
        private readonly ICerficationsService certificationsService;

        public CertificationsController(
            UserManager<ApplicationUser> userManager,
            IUsersService usersService,
            ICerficationsService certificationsService)
        {
            this.userManager = userManager;
            this.usersService = usersService;
            this.certificationsService = certificationsService;
        }

        public IActionResult AddCertification()
        {
            var userId = this.userManager.GetUserId(this.User);

            var years = this.certificationsService.GetYears();

            var viewModel = new CertificationCreateInputModel
            {
                UserId = userId,
                Years = years,
            };

            return this.PartialView(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddCertification(CertificationCreateInputModel input)
        {
            await this.certificationsService.CreateAsync(input.Certificate, input.CertifiedFrom, input.Year, input.UserId);

            return this.RedirectToAction("Profile", "Users", new { userId = input.UserId });
        }

        public async Task<IActionResult> EditCertification(int id)
        {
            var certification = await this.certificationsService.GetByIdAsync<CertificationEditViewModel>(id);

            var viewModel = new CertificationEditInputModel
            {
                Certificate = certification.Certificate,
                CertifiedFrom = certification.CertifiedFrom,
                Year = certification.Year,
                UserId = certification.UserId,
            };

            return this.PartialView(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditCertification(CertificationEditInputModel input)
        {
            var userId = this.userManager.GetUserId(this.User);

            await this.certificationsService.EditAsync(input.Id, input.Certificate, input.CertifiedFrom, input.Year);

            return this.RedirectToAction("Profile", "Users", new { userId = userId });
        }
    }
}
