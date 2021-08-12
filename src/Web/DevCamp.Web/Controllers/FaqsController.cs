namespace DevCamp.Web.Controllers
{
    using System.Threading.Tasks;

    using DevCamp.Data.Models;
    using DevCamp.Services.Data.Interfaces;
    using DevCamp.Web.ViewModels.FAQs;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class FaqsController : Controller
    {
        private readonly IFaqService faqService;

        public FaqsController(
            IFaqService faqService)
        {
            this.faqService = faqService;
        }

        public IActionResult Create(int listingId)
        {
            var viewModel = new FaqCreateInputModel
            {
                ListingId = listingId,
            };

            return this.PartialView(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(FaqCreateInputModel input)
        {
            await this.faqService.CreateAsync(
                input.Question,
                input.Answer,
                input.ListingId);

            return this.RedirectToAction("PersonalListing", "Listings", new { Id = input.ListingId });
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

            return this.PartialView(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(FaqEditInputModel input)
        {
            await this.faqService.EditAsync(
                input.Id,
                input.Question,
                input.Answer);

            return this.RedirectToAction("PersonalListing", "Listings", new { Id = input.ListingId });
        }
    }
}
