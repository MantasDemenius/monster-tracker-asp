using System;
using System.Collections.Generic;

namespace monster_tracker_asp.Models
{
    public partial class Type
    {
        public int Id { get; set; }
        public int MonsterId { get; set; }
        public string TypeCode { get; set; }
        public string Name { get; set; }
        public string SysDeleteStatus { get; set; }

        public Monster Monster { get; set; }
    }
}
