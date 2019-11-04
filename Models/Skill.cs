﻿using System;
using System.Collections.Generic;
namespace monster_tracker_asp.Models
{
    public partial class Skill
    {
        public Skill()
        {
            Monster = new HashSet<Monster>();
        }

        public int Id { get; set; }
        public int? Acrobatics { get; set; }
        public int? AnimalHandling { get; set; }
        public int? Arcana { get; set; }
        public int? Athletics { get; set; }
        public int? Deception { get; set; }
        public int? History { get; set; }
        public int? Insight { get; set; }
        public int? Intimidation { get; set; }
        public int? Investigation { get; set; }
        public int? Medicine { get; set; }
        public int? Nature { get; set; }
        public int? Perception { get; set; }
        public int? Performance { get; set; }
        public int? Persuasion { get; set; }
        public int? Religion { get; set; }
        public int? SleightOfHand { get; set; }
        public int? Stealth { get; set; }
        public int? Survival { get; set; }
        public string SysDeleteStatus { get; set; }

        public ICollection<Monster> Monster { get; set; }
    }
}
