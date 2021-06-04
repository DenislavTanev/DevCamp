namespace DevCamp.Web.ViewModels.Categories
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using DevCamp.Data.Models;
    using DevCamp.Services.Mapping;

    public class CategoriesViewModel : IMapFrom<Category>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
