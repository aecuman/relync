using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Relync2.Models
{
    public class Property
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Terms { get; set; }
        public string Currency { get; set; }
        public double Price { get; set; }
        public string Images { get; set; }
        public bool Available { get; set; }
        public string UserID { get; set; }

    }
}
