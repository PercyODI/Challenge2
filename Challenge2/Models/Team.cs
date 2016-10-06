using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Challenge2.Models
{
    public class Team
    {
        public Team()
        {
            Players = new List<Player>();
        }

        [Key]
        public string Name { get; set; }
        public string City { get; set; }

        [Required]
        public virtual Stadium Stadium { get; set; }

        
        public virtual List<Player> Players { get; set; }
    }
}