using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIassignment2.Models
{
    public class SkillsProjects : BaseDomain<int>
    {
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        public int SkillId { get; set; }
        public Skill Skill { get; set; }
    }
}
