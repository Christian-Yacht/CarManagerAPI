using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIassignment2.Models
{
    public class Car : BaseDomain<int>
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public string Description { get; set; }
        public double Range { get; set; }
        public double MileAge { get; set; }

        public Company CarCompany { get; set; }
        public int CarCompanyId { get; set; }
        public User CarUser { get; set; }
        public int CarUserId { get; set; }

        public Car()
        {

        }
    }
}
