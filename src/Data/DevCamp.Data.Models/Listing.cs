namespace DevCamp.Data.Models
{
    using System.Collections.Generic;

    using DevCamp.Data.Common.Models;

    public class Listing : BaseDeletableModel<int>
    {
        public Listing()
        {
            this.Packages = new HashSet<Package>();
            this.Reviews = new HashSet<Review>();
            this.Faqs = new HashSet<FrequentlyAskedQuestion>();
        }

        public string Title { get; set; }

        public string ProjectDetails { get; set; }

        public double? StartingPrice { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public int SubCategoryId { get; set; }

        public SubCategory SubCategory { get; set; }

        public ICollection<Package> Packages { get; set; }

        public ICollection<Review> Reviews { get; set; }

        public ICollection<FrequentlyAskedQuestion> Faqs { get; set; }
    }
}
