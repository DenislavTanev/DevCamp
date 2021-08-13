namespace DevCamp.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using DevCamp.Data.Models;

    public class SkillsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (!dbContext.Skills.Any())
            {
                var skills = new List<string>
                   {
                       "Problemsolving",
                       "Facebookads",
                       "Seo",
                       "Social Media Marketing",
                       "Instagram Marketing",
                       "Facebook Marketing",
                       "WordPress",
                       "ASP.NET",
                       "Angular.js",
                   };

                foreach (var skill in skills)
                {
                    await dbContext.Skills.AddAsync(new Skill
                    {
                        TechnologyName = skill,
                    });
                }
            }
        }
    }
}
