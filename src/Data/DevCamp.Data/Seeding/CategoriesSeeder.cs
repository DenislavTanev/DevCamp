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
                    "Logo Design",
                    "Game Art",
                    "Business Cards & Stationery",
                    "Illustration",
                    "Pattern Design",
                    "Packaging Design",
                    "Brochure Design",
                    "Poster Design",
                    "Signage Design",
                    "Flyer Design",
                    "Album Cover Design",
                    "Website Design",
                    "App Design",
                    "UX Design",
                    "Landing Page Design",
                    "Icon Design",
                    "Catalog Design",
                    "Portraits & Caricatures",
                    "Cartoons & Comics",
                    "Web Banner",
                    "Photoshop Editing",
                    "Architecture & Interior Design",
                    "Landscape Design",
                    "Character Modeling",
                    "T-Shirts & Merchandise",
                    "Menu Design",
                };

                var digitalMarketingCategories = new List<string>
                {
                    "Social Media Marketing",
                    "Social Media Advertising",
                    "Content Marketing",
                    "Video Marketing",
                    "Email Marketing",
                    "Crowdfunding",
                    "Display Advertising",
                    "Marketing Strategy",
                    "Web Analytics",
                    "Book & eBook Marketing",
                    "Influencer Marketing",
                    "Community Management",
                    "E-Commerce Marketing",
                    "Affiliate Marketing",
                    "Mobile App Marketing",
                    "Text Message Marketing",
                };

                var videoCategories = new List<string>
                {
                    "Video Editing",
                    "Short Video Ads",
                    "Animated GIFs",
                    "Logo Animation",
                    "Intros & Outros",
                    "App & Website Previews",
                    "Character Animation",
                    "3D Product Animation",
                    "E-Commerce Product Videos",
                    "Website Animations",
                    "Lyric & Music Videos",
                    "Subtitles & Captions",
                    "Visual Effects",
                    "Drone Videography",
                    "Screencasting Videos",
                    "Game Trailers",
                    "Product Photography",
                    "Local Photography",
                    "Sound Effects",
                };

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

                var designSector = await dbContext.Sectors.FirstOrDefaultAsync(x => x.Name == "Graphics & Design");
                var digitalMarketingSector = await dbContext.Sectors.FirstOrDefaultAsync(x => x.Name == "Digital Marketing");
                var videoSector = await dbContext.Sectors.FirstOrDefaultAsync(x => x.Name == "Video & Animation");
                var programmingSector = await dbContext.Sectors.FirstOrDefaultAsync(x => x.Name == "Programming & Tech");
                var dataSector = await dbContext.Sectors.FirstOrDefaultAsync(x => x.Name == "Data");

                foreach (var category in designCategories)
                {
                    await dbContext.Categories.AddAsync(new Category
                    {
                        Name = category,
                        SectorId = designSector.Id,
                    });
                }

                foreach (var category in digitalMarketingCategories)
                {
                    await dbContext.Categories.AddAsync(new Category
                    {
                        Name = category,
                        SectorId = digitalMarketingSector.Id,
                    });
                }

                foreach (var category in videoCategories)
                {
                    await dbContext.Categories.AddAsync(new Category
                    {
                        Name = category,
                        SectorId = videoSector.Id,
                    });
                }

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
