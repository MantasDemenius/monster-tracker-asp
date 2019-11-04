using System;
using System.Collections.Generic;

namespace monster_tracker_asp.Models
{
    public partial class Action
    {
        public Action()
        {
            MonsterActionLink = new HashSet<MonsterActionLink>();
        }

        public int Id { get; set; }
        public string Ability { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string AttackBonus { get; set; }
        public string DamageDice { get; set; }
        public string DamageBonus { get; set; }
        public string SysDeleteStatus { get; set; }

        public ICollection<MonsterActionLink> MonsterActionLink { get; set; }
    }
}
