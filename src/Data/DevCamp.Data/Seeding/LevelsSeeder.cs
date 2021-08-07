using DevCamp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevCamp.Data.Seeding
{
    public class LevelsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (!dbContext.Levels.Any())
            {
                var levels = new List<string>
                {
                    "Basic",
                    "Conversational",
                    "Fluent",
                    "Native/Bilingual",
                };

                foreach (var level in levels)
                {
                    await dbContext.Levels.AddAsync(new Level
                    {
                        Name = level,
                    });
                }
            }
        }
    }
}
