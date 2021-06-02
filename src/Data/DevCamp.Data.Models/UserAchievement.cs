namespace DevCamp.Data.Models
{
    public class UserAchievement
    {
        public int Id { get; set; }

        public int AchievementId { get; set; }

        public Achievement Achievement { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public int Progress { get; set; }

        public bool IsOwned { get; set; }
    }
}
