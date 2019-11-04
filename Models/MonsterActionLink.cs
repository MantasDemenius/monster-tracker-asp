using System;
using System.Collections.Generic;

namespace monster_tracker_asp.Models
{
    public partial class MonsterActionLink
    {
        public int MonsterId { get; set; }
        public int ActionId { get; set; }

        public Action Action { get; set; }
        public Monster Monster { get; set; }
    }
}
