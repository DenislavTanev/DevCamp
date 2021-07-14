namespace DevCamp.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using DevCamp.Data.Models;
    using DevCamp.Services.Data.Interfaces;
    using DevCamp.Web.ViewModels.FAQs;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class FaqsController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IFaqService faqService;

        public FaqsController(
            UserManager<ApplicationUser> userManager,
            IFaqService faqService)
        {
            this.userManager = userManager;
            this.faqService = faqService;
        }

        public IActionResult Index(int listingId)
        {
            var faqs = this.faqService.GetAll<FaqViewModel>(listingId);

            return this.View(faqs);
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(FaqCreateInputModel input)
        {
            await this.faqService.CreateAsync(
                input.Question,
                input.Answer,
                (int)input.ListingId);

            return this.RedirectToAction("Index", "Listings");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var faq = await this.faqService.GetByIdAsync<FaqEditViewModel>(id);

            var viewModel = new FaqEditInputModel
            {
                Question = faq.Question,
                Answer = faq.Answer,
                Id = faq.Id,
                ListingId = faq.ListingId,
            };

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(FaqEditInputModel input)
        {
            await this.faqService.EditAsync(
                input.Id,
                input.Question,
                input.Answer);

            return this.RedirectToAction("Index", "Listings");
        }
    }
}
