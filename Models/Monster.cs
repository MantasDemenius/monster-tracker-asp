using System;
using System.Collections.Generic;

namespace monster_tracker_asp.Models
{
    public partial class Monster
    {
        public Monster()
        {
            MonsterActionLink = new HashSet<MonsterActionLink>();
            MonsterUserAccessibilityLink = new HashSet<MonsterUserAccessibilityLink>();
            Score = new HashSet<Score>();
            Type = new HashSet<Type>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public int SkillId { get; set; }
        public string Name { get; set; }
        public string Size { get; set; }
        public string Alignment { get; set; }
        public string ArmorClass { get; set; }
        public int? HitPoints { get; set; }
        public string HitDice { get; set; }
        public string Speed { get; set; }
        public string Vulnerability { get; set; }
        public string Resistance { get; set; }
        public string Immunity { get; set; }
        public string ConditionImmunity { get; set; }
        public string Sense { get; set; }
        public string Language { get; set; }
        public string ChallengeRating { get; set; }
        public DateTimeOffset CreationTime { get; set; }
        public string Visibility { get; set; }
        public string Picture { get; set; }
        public string PictureAuthor { get; set; }
        public string SysDeleteStatus { get; set; }

        public Skill Skill { get; set; }
        public User User { get; set; }
        public ICollection<MonsterActionLink> MonsterActionLink { get; set; }
        public ICollection<MonsterUserAccessibilityLink> MonsterUserAccessibilityLink { get; set; }
        public ICollection<Score> Score { get; set; }
        public ICollection<Type> Type { get; set; }
    }
}
