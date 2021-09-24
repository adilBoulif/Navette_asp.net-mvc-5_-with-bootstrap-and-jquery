using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Navette.Models
{
    public class Strans
    {
        public int Id { get; set; }
        [Required]
        public string nom { get; set; }
        [Required]
        public string email { get; set; }
        
        public string image { get; set; }
        [Required]
        public string telephone { get; set; }
        [Required]
        public string Adresse { get; set; }
        public virtual ICollection<Offres> Offres { get; set; }
    }
}