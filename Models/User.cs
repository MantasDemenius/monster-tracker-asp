using System;
using System.Collections.Generic;

namespace monster_tracker_asp.Models
{
    public partial class User
    {
        public User()
        {
            Monster = new HashSet<Monster>();
            MonsterUserAccessibilityLink = new HashSet<MonsterUserAccessibilityLink>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Passwordhash { get; set; }
        public string Passwordsalt { get; set; }
        public string SysDeleteStatus { get; set; }

        public ICollection<Monster> Monster { get; set; }
        public ICollection<MonsterUserAccessibilityLink> MonsterUserAccessibilityLink { get; set; }
    }
}
