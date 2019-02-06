using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIassignment2.Models
{
    public class BaseDomain<TId>
    {
        [Key]
        public TId Id { get; set; }
    }
}
