using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Navette.Models
{
    public class DemandeClient
    {
        public int id { get; set; }

        public string depart { get; set; }
        public string destination{ get; set; }
        public string h_depart { get; set; }
        public string h_destination { get; set; }
        public int num_demande { get; set; }
        public string userId { get; set; }
       
        public virtual ApplicationUser user { get; set; }
    }
}