using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Relync2.Models
{
    public class Request
    {
      public int id { get; set; }
        [Display(Name ="Transaction Type")]
        public string Ttype { get; set; }
        [Required]
        [Display(Name = "Property Type")]
        public string Ptype { get; set; }
        [Required]
        public string Urgency { get; set; }
        public string Location { get; set; }
        [Required(ErrorMessage ="Select the Currency")]
        
        public string Currency { get; set; }
        [Required]
        [Display(Name ="Highest Price")]
        public double? Highest { get; set; }
        [Display(Name = "Lowest Price")]
        [Required]
        public double? Lowest { get; set; }
        [Required]
        public string Attributes { get; set; }
        public bool Active { get; set; }
        public string UserID { get; set; }
        public DateTime Dated { get; set; }
    }
}
