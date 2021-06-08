namespace DevCamp.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using DevCamp.Data.Models;

    public class LanguagesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (!dbContext.Languages.Any())
            {
                var languages = new List<string>
                {
                    "English",
                    "Spanish",
                    "French",
                    "German",
                    "Italian",
                    "Bulgarian",
                    "Russian",
                    "Turkish",
                };

                foreach (var language in languages)
                {
                    await dbContext.Languages.AddAsync(new Language
                    {
                        Name = language,
                    });
                }
            }
        }
    }
}
