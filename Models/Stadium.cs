using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Challenge2.Models
{
    public class Stadium
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public decimal TicketPrice { get; set; }
    }
}