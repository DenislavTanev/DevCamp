namespace DevCamp.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using DevCamp.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class SubCategoriesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (!dbContext.SubCategories.Any())
            {
                var subCategories = new Dictionary<string, List<string>>();
                subCategories.Add(
                    "WordPress", new List<string>
                    {
                        "Full Website Creation",
                        "Customization",
                        "Bug Fixes",
                        "Performance",
                        "Landing Page",
                    });
                subCategories.Add(
                    "Website Builders & CMS", new List<string>
                    {
                        "Full Website Creation",
                        "Customization",
                        "Bug Fixes",
                        "Landing Page",
                        "Performance & Security",
                    });
                subCategories.Add(
                    "E-Commerce Development", new List<string>
                    {
                        "Full Website Creation",
                        "Customization",
                        "Theme/Plugin Installation",
                        "Backup & Migration",
                        "Performance & Security",
                    });
                subCategories.Add(
                    "Mobile Apps", new List<string>
                    {
                        "Custom App",
                        "Convert Site to App",
                        "Bug Fixes",
                        "App Improvements",
                    });
                subCategories.Add(
                    "Web Programming", new List<string>
                    {
                        "Web Application",
                        "Custom Website",
                        "Bug Fixes",
                        "Scripting",
                        "Landing Page",
                    });
                subCategories.Add(
                    "Desktop Applications", new List<string>
                    {
                        "Custom Application",
                        "Application Improvements",
                        "Bug Fixes",
                    });
                subCategories.Add(
                    "Logo & Brand Identity", new List<string>
                    {
                        "Logo Design",
                        "Brand Style Guides",
                        "Business Cards & Stationery",
                    });
                subCategories.Add(
                    "Web & App Design", new List<string>
                    {
                        "Website Design",
                        "Web Banners",
                        "Landing Page Design",
                        "App Design",
                        "UX Design",
                    });
                subCategories.Add(
                    "Visual Design", new List<string>
                    {
                        "Photoshop Editing",
                        "Presentation Design",
                        "Infographic Design",
                        "Vector Tracing",
                        "Resume Design",
                    });
                subCategories.Add(
                    "Packaging & Labels", new List<string>
                    {
                        "Packaging Design",
                        "Book Design",
                        "Album Cover Design",
                        "Podcast Cover Art",
                        "Car Wraps",
                    });
                subCategories.Add(
                    "Fashion & Merchandise", new List<string>
                    {
                        "Fashion Design",
                        "T-Shirt & Merchandise",
                        "Jewelry Design",
                        "Tattoo Design",
                    });
                subCategories.Add(
                    "Print Design", new List<string>
                    {
                        "Flyer Design",
                        "Brochure Design",
                        "Poster Design",
                        "Catalog Design",
                        "Postcard Design",
                    });
                subCategories.Add(
                    "Programming", new List<string>
                    {
                        "Scripts",
                        "Platform Migration",
                        "Backup & Migration",
                        "Prototyping",
                        "Bug Fixes",
                    });
                subCategories.Add(
                    "Audio", new List<string>
                    {
                        "Sound Design",
                        "Voice Over",
                        "Dialogue Editing",
                        "Beat Making",
                    });
                subCategories.Add(
                    "Animation", new List<string>
                    {
                        "Character & Object Movements",
                        "Particles",
                        "3D Animation",
                        "2D Animation",
                        "Motion Capture",
                    });
                subCategories.Add(
                    "Game Art", new List<string>
                    {
                        "Character Design",
                        "Props & Objects",
                        "UI & UX",
                        "Art Concepts",
                        "Particle Design",
                    });
                subCategories.Add(
                    "Landscape", new List<string>
                    {
                        "Level Design",
                        "Backgrounds Design",
                        "Map Design",
                        "Environment",
                    });
                subCategories.Add(
                    "Merchandise", new List<string>
                    {
                        "Trailers",
                        "Banners & Thumbnails",
                        "Adds",
                    });

                foreach (var subCategory in subCategories)
                {
                    var categoryName = subCategory.Key;

                    var currCategory = await dbContext.Categories.FirstOrDefaultAsync(x => x.Name == categoryName);

                    foreach (var sub in subCategory.Value)
                    {
                        await dbContext.SubCategories.AddAsync(new SubCategory
                        {
                            Name = sub,
                            CategoryId = currCategory.Id,
                        });
                    }
                }
            }
        }
    }
}
