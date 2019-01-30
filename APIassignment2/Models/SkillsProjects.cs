using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIassignment2.Models
{
    public class SkillsProjects
    {
        [Key]
        public int Id { get; set; }
        public string ProjectTitle { get; set; }
        public Project Project { get; set; }
        public string SkillTitle { get; set; }
        public Skill Skill { get; set; }
    }
}
