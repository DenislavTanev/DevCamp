namespace DevCamp.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using DevCamp.Data.Models;
    using DevCamp.Services.Data.Interfaces;
    using DevCamp.Web.ViewModels.DropDownModels;
    using DevCamp.Web.ViewModels.Educations;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class EducationsController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IEducationsService educationsService;
        private readonly ICountriesService countriesService;

        public EducationsController(
            UserManager<ApplicationUser> userManager,
            IEducationsService educationsService,
            ICountriesService countriesService)
        {
            this.userManager = userManager;
            this.educationsService = educationsService;
            this.countriesService = countriesService;
        }

        public IActionResult AddEducation()
        {
            var userId = this.userManager.GetUserId(this.User);

            var countries = this.countriesService.GetAll<CountriesDropDownViewModel>();
            var titles = this.educationsService.GetTitle();
            var years = this.educationsService.GetYears();

            var viewModel = new EducationCreateInputModel
            {
                Countries = countries,
                Titles = titles,
                Years = years,
                UserId = userId,
            };

            return this.PartialView(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddEducation(EducationCreateInputModel input)
        {
            await this.educationsService.CreateAsync(
                input.UniversityName,
                input.UniversityLocation,
                input.Title,
                input.Major,
                input.GraduationYear,
                input.UserId);

            return this.RedirectToAction("Profile", "Users", new { userId = input.UserId });
        }

        public async Task<IActionResult> EditEducation(int id)
        {
            var education = await this.educationsService.GetByIdAsync<EducationEditViewModel>(id);

            var countries = this.countriesService.GetAll<CountriesDropDownViewModel>();
            var titles = this.educationsService.GetTitle();
            var years = this.educationsService.GetYears();

            var viewModel = new EducationEditInputModel
            {
                UniversityName = education.UniversityName,
                UniversityLocation = education.UniversityLocation,
                Title = education.Title,
                Major = education.Major,
                GraduationYear = education.GraduationYear,
                UserId = education.UserId,
                Countries = countries,
                Titles = titles,
                Years = years,
            };

            return this.PartialView(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditEducation(EducationEditInputModel input)
        {
            await this.educationsService.EditAsync(
                input.Id,
                input.UniversityName,
                input.UniversityLocation,
                input.Title,
                input.Major,
                input.GraduationYear);

            return this.RedirectToAction("Profile", "Users", new { userId = input.UserId });
        }

        public async Task<IActionResult> DeleteEducation(int id)
        {
            var userId = this.userManager.GetUserId(this.User);

            await this.educationsService.DeleteAsync(id);

            return this.RedirectToAction("Profile", "Users", new { userId = userId });
        }
    }
}
