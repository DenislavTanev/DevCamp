namespace DevCamp.Data.Models
{
    public class ListingSkill
    {
        public int Id { get; set; }

        public int SkillId { get; set; }

        public Skill Skill { get; set; }

        public int ListingId { get; set; }

        public Listing Listing { get; set; }
    }
}
