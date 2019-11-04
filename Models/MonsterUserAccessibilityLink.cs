using System;
using System.Collections.Generic;

namespace monster_tracker_asp.Models
{
    public partial class MonsterUserAccessibilityLink
    {
        public int UserId { get; set; }
        public int MonsterId { get; set; }

        public Monster Monster { get; set; }
        public User User { get; set; }
    }
}
