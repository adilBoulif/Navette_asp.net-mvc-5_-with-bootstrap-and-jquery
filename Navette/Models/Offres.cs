using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Navette.Models
{
    public class Offres
    {

        public int Id { get; set; }
        [Required]
        public string description { get; set; }
        [Required]
        public string depart { get; set; }
        [Required]
        public string destination { get; set; }
        [Required]
        public string h_depart { get; set; }
        [Required]
        public string h_retour { get; set; }
        [Required]
        public string place { get; set; }
        [Required]
        public string prix { get; set; }
        [Required]
        public int stransId { get; set; }
        public virtual Strans strans { get; set; }
    }
}