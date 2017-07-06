using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Relync2.Models
{
    public class Activity
    {
        
       
        public int Id { get; set; }
        public string Type { get; set; }
        public string UserID { get; set; }
        public int PropertyID { get; set; }        
        public int RequestID { get; set; }
        public DateTime On { get; set; }
    }
}
