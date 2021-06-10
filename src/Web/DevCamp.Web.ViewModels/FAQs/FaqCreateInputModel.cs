namespace DevCamp.Web.ViewModels.FAQs
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    using DevCamp.Data.Models;
    using DevCamp.Services.Mapping;

    public class FaqCreateInputModel : IMapTo<FrequentlyAskedQuestion>
    {
        [Required(ErrorMessage = "The field is required!")]
        [MinLength(20, ErrorMessage = "The field requires more than 20 characters!")]
        [MaxLength(200, ErrorMessage = "The field must not be more than 200 characters!")]
        [DisplayName("Question")]
        public string Question { get; set; }

        [Required(ErrorMessage = "The field is required!")]
        [MinLength(20, ErrorMessage = "The field requires more than 20 characters!")]
        [MaxLength(200, ErrorMessage = "The field must not be more than 200 characters!")]
        [DisplayName("Answer")]
        public string Answer { get; set; }

        public int ListingId { get; set; }
    }
}
