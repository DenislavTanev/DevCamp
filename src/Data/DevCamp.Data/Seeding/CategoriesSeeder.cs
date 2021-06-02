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
               var programmingCategories = new List<string>
               {
                   "WordPress",
                   "Website Builders & CMS",
                   "E-Commerce Development",
                   "Game Development",
                   "Development for Streamers",
                   "Mobile Apps",
                   "Web Programming",
                   "Desktop Applications",
                   "Chatbots",
                   "Cybersecurity & Data Protection",
                   "User Testing",
                   "QA & Review",
               };

               var dataCategories = new List<string>
               {
                   "Databases",
                   "Data Analytics",
                   "Data Processing",
                   "Data Visualization",
                   "Data Entry",
               };

               var programmingSector = await dbContext.Sectors.FirstOrDefaultAsync(x => x.Name == "Programming & Tech");
               var dataSector = await dbContext.Sectors.FirstOrDefaultAsync(x => x.Name == "Data");

               foreach (var category in programmingCategories)
               {
                   await dbContext.Categories.AddAsync(new Category
                   {
                       Name = category,
                       SectorId = programmingSector.Id,
                   });
               }

               foreach (var category in dataCategories)
               {
                   await dbContext.Categories.AddAsync(new Category
                   {
                       Name = category,
                       SectorId = dataSector.Id,
                   });
               }
           }
        }
    }
}
