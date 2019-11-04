using System;
using System.Collections.Generic;

namespace monster_tracker_asp.Models
{
    public partial class Score
    {
        public int Id { get; set; }
        public int MonsterId { get; set; }
        public string ScoreTypeCode { get; set; }
        public int? Strength { get; set; }
        public int? Dexterity { get; set; }
        public int? Constitution { get; set; }
        public int? Intelligence { get; set; }
        public int? Wisdom { get; set; }
        public int? Charisma { get; set; }
        public string SysDeleteStatus { get; set; }

        public Monster Monster { get; set; }
    }
}
