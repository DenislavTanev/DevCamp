﻿namespace DevCamp.Data.Models
{
    public class UserSkill
    {
        public int Id { get; set; }

        public int SkillId { get; set; }

        public Skill Skill { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }
    }
}
