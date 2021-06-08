namespace DevCamp.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using DevCamp.Data.Models;

    public class ItemsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (!dbContext.Items.Any())
            {
                var items = new List<string>
                {
                    "Revisions",
                    "Delivery Time",
                    "Number of Products",
                    "Plugins/Extensions Installation",
                    "Total",
                    "Number of Pages",
                    "E-Commerce Functionality",
                    "Responsive Design",
                    "Content Upload",
                    "Design Customization",
                };

                foreach (var item in items)
                {
                    await dbContext.Items.AddAsync(new Item
                    {
                        Name = item,
                    });
                }
            }
        }
    }
}
