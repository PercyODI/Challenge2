using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Challenge2.Models
{
    public class Team
    {
        [Key]
        public string Name { get; set; }
        public string City { get; set; }
        public virtual Stadium Stadium { get; set; }
        public virtual List<Player> Players { get; set; }
    }
}