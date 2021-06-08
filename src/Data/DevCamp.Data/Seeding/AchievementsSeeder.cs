namespace DevCamp.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using DevCamp.Data.Models;

    public class AchievementsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (!dbContext.Achievements.Any())
            {
                var achievements = new Dictionary<string, string>();
                achievements.Add("Level 1", "Complete 100 projects successfuly.");
                achievements.Add("Level 2", "Complete 1000 projects successfuly.");
                achievements.Add("Approved", "Contact us and show your skills.");
                achievements.Add("Pro", "Have 100 reviews 4.8 stars or higher.");

                foreach (var achievement in achievements)
                {
                    await dbContext.Achievements.AddAsync(new Achievement
                    {
                        Name = achievement.Key,
                        Requirements = achievement.Value,
                    });
                }
            }
        }
    }
}
