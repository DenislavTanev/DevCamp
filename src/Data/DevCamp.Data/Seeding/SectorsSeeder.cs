namespace DevCamp.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using DevCamp.Data.Models;

    public class SectorsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
               if (!dbContext.Sectors.Any())
               {
                   var sectors = new List<string>
                   {
                       "Design",
                       "Web Applications",
                       "Game Development",
                   };

                   foreach (var sector in sectors)
                   {
                       await dbContext.Sectors.AddAsync(new Sector
                       {
                           Name = sector,
                       });
                   }
               }
        }
    }
}
