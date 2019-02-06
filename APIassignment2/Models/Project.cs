using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIassignment2.Models
{
    public class Project : BaseDomain<int>
    {
        public string ProjectTitle { get; set; }
        public string Description { get; set; }
        public ICollection<SkillsProjects> SkillsProjects { get; set; }
        public ICollection<UsersProjects> UsersProjects { get; set; }
    }
}
