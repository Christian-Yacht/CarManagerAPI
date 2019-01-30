using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIassignment2.Models
{
    public class UserSkills
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        public User User { get; set; }
        public string SkillTitle { get; set; }
        public Skill Skill { get; set; }
    }
}
