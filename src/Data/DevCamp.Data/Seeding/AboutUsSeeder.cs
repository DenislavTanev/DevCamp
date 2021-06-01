namespace DevCamp.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using DevCamp.Data.Models;

    public class AboutUsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (!dbContext.AboutUs.Any())
            {
                var aboutUs = new AboutUs
                {
                    Email = "devcamp.bg@gmail.com",
                    Phone = "0888111222",
                    Address = "..",
                    LocationUrlForGoogleMaps =
                        "..",
                    LocationUrlForOpenStreetMap =
                        "..",
                };

                await dbContext.AboutUs.AddAsync(aboutUs);
            }
        }
    }
}
