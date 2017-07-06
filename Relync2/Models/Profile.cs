using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Relync2.Models
{
    public class Profile
    {
        public int Id { get; set; }
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Surname { get; set; }
        public string Othernames { get; set; }
        public string Pic { get; set; }
        public string Email { get; set; }
        
        public string Phonenumber { get; set; }
        public string Username { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime EditedOn { get; set; }
    }
}
