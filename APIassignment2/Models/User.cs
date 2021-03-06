﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIassignment2.Models
{
    public class User : BaseDomain<int>
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int Age { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string LastActivityDate { get; set; }

        public IList<Car> Cars { get; set; }

        public ICollection<UserSkills> UserSkills { get; set; }
        public ICollection<UsersProjects> UsersProjects { get; set; }

        public User()
        {

        }
    }
}
