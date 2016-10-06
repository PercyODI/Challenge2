using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace Challenge2.Models
{
    public class Stadium {

        //[Key, ForeignKey("Team")]
        //public string TeamName { get; set; }
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public decimal TicketPrice { get; set; }

        //[ScriptIgnore]
        //public virtual Team Team { get; set; }

    }
}