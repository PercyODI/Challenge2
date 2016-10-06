using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace Challenge2.Models
{
    public class Player
    {
        //[Key]
        public int PlayerId { get; set; }
        //[ForeignKey("Team")]
        //public string TeamName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public decimal Salary { get; set; }

        //[ForeignKey("TeamName")]
        //[ScriptIgnore]
        //public virtual Team Team { get; set; }
    }
}