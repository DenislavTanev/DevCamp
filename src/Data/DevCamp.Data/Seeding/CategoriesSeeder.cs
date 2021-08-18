namespace DevCamp.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using DevCamp.Data.Models;

    using Microsoft.EntityFrameworkCore;

    public class CategoriesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (!dbContext.Categories.Any())
            {
                var designCategories = new List<string>
               {
                   "Logo & Brand Identity",
                   "Web & App Design",
                   "Visual Design",
                   "Packaging & Labels",
                   "Fashion & Merchandise",
                   "Print Design",
               };

                var webCategories = new List<string>
               {
                   "WordPress",
                   "Website Builders & CMS",
                   "E-Commerce Development",
                   "Mobile Apps",
                   "Web Programming",
                   "Desktop Applications",
               };

                var gameCategories = new List<string>
               {
                   "Programming",
                   "Audio",
                   "Animation",
                   "Game Art",
                   "Landscape",
                   "Merchandise",
               };

                var designSector = await dbContext.Sectors.FirstOrDefaultAsync(x => x.Name == "Design");
                var webSector = await dbContext.Sectors.FirstOrDefaultAsync(x => x.Name == "Web Applications");
                var gameSector = await dbContext.Sectors.FirstOrDefaultAsync(x => x.Name == "Game Development");

                foreach (var category in webCategories)
                {
                    await dbContext.Categories.AddAsync(new Category
                    {
                        Name = category,
                        SectorId = webSector.Id,
                    });
                }

                foreach (var category in gameCategories)
                {
                    await dbContext.Categories.AddAsync(new Category
                    {
                        Name = category,
                        SectorId = gameSector.Id,
                    });
                }

                foreach (var category in designCategories)
                {
                    await dbContext.Categories.AddAsync(new Category
                    {
                        Name = category,
                        SectorId = designSector.Id,
                    });
                }
            }
        }
    }
}
