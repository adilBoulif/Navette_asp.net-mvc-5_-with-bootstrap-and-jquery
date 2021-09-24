using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Navette.Models
{
    public class Abonments
    {
        public int id { get; set; }

        public DateTime date_Abon { get; set; }
        public int OffreId { get; set; }
        public string userId { get; set; }
        public virtual Offres Offre { get; set; }
        public virtual ApplicationUser user { get; set; }
    }
}