namespace DevCamp.Web.Controllers
{
    using System.Diagnostics;
    using System.Linq;

    using DevCamp.Services.Data.Interfaces;
    using DevCamp.Web.ViewModels;
    using DevCamp.Web.ViewModels.DropDownModels;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : Controller
    {
        private readonly ICategoriesService categoriesService;
        private readonly ISectorsService sectorsService;

        public HomeController(
            ICategoriesService categoriesService,
            ISectorsService sectorsService)
        {
            this.categoriesService = categoriesService;
            this.sectorsService = sectorsService;
        }

        public IActionResult Index()
        {
            return this.View();
        }

        public IActionResult Test()
        {
            return this.View();
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }

        public IActionResult Design()
        {
            var sector = this.sectorsService.GetAll<SectorsDropDownViewModel>().FirstOrDefault(x => x.Name == "Design");
            var categories = this.categoriesService.GetAll<CategoriesDropDownViewModel>(sector.Id);

            return this.View(categories);
        }

        public IActionResult WebApplications()
        {
            var sector = this.sectorsService.GetAll<SectorsDropDownViewModel>().FirstOrDefault(x => x.Name == "Web Applications");
            var categories = this.categoriesService.GetAll<CategoriesDropDownViewModel>(sector.Id);

            return this.View(categories);
        }

        public IActionResult GameDevelopment()
        {
            var sector = this.sectorsService.GetAll<SectorsDropDownViewModel>().FirstOrDefault(x => x.Name == "Game Development");
            var categories = this.categoriesService.GetAll<CategoriesDropDownViewModel>(sector.Id);

            return this.View(categories);
        }
    }
}
