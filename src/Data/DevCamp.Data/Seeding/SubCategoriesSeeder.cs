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
                        "Backup & Migration",
                        "Security",
                    });
                subCategories.Add(
                    "Website Builders & CMS", new List<string>
                    {
                        "Full Website Creation",
                        "Customization",
                        "Bug Fixes",
                        "Theme/Plugin Installation",
                        "Landing Page",
                        "Backup & Migration",
                        "Performance & Security",
                    });
                subCategories.Add(
                    "E-Commerce Development", new List<string>
                    {
                        "Full Website Creation",
                        "Customization",
                        "Bug Fixes",
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
                        "Convert PSD",
                        "Landing Page",
                        "Email Template",
                        "Browser Extensions",
                    });
                subCategories.Add(
                    "Desktop Applications", new List<string>
                    {
                        "Custom Application",
                        "Application Improvements",
                        "Bug Fixes",
                    });
                subCategories.Add(
                    "Cybersecurity & Data Protection", new List<string>
                    {
                        "Assessment & Penetration Test",
                        "Cybersecurity Management",
                        "Compliance Services",
                    });
                subCategories.Add(
                    "QA & Review", new List<string>
                    {
                        "Software Testing",
                        "Code Review",
                        "Design Review",
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
