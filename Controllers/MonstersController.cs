using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using monster_tracker_asp.Models;
using System.Collections.Generic;
using System.Linq;

namespace monster_tracker_asp.Controllers
{
    public class MonstersController: Controller
    {
        public IActionResult Index()
        {
            //int Id = 1;
            //if (Id == null)
            //{
            //    return NotFound();
            //}
            using (var _context = new mtprodContext())
            {
                //var MonsterList = (from M in _context.Monster
                //                   join S in _context.Skill on M.SkillId equals S.Id
                //                   join U in _context.User on M.UserId equals U.Id
                //                   select new MonsterFullModel {
                //                       monster = M ,
                //                       skill = S ,
                //                       user = U
                //                   });
                //var values = MonsterList.Select(x => x.monster.Id).ToList();
                //var answer = _context.Score.Where(p => values.Contains(p.MonsterId)).ToList();
                var text = _context.Monster
                    .Include(user => user.User)
                    .Include(type => type.Type)
                    .Include(skill => skill.Skill)
                    .Include(score => score.Score)
                    .Include(ActionLink => ActionLink.MonsterActionLink)
                    .ToList();
                //var test = _context.MonsterActionLink
                //    .Include(ActionLink => ActionLink.Action)
                //    .Include(monster => monster.Monster)
                //    .ThenInclude(a => a.User)
                //    .Include(monster => monster.Monster)
                //    .ThenInclude(a => a.Type)
                //    .Include(monster => monster.Monster)
                //    .ThenInclude(a => a.Skill)
                //    .Include(monster => monster.Monster)
                //    .ThenInclude(a => a.Score)
                //    .ToList();
                return View(text);
            }

        }
    }
}