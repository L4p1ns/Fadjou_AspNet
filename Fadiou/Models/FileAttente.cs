using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fadiou.Models
{
    public class FileAttente
    {
        [Key]
        public int IdFileA { get; set; }

        [Display(Name = "Date Rendez vous")]
        public DateTime DateFileA { get; set; }

        public int IdRendezVous { get; set; }
        [ForeignKey("idRendezVous")]
        public virtual RendezVous rendezVous { get; set; }

        //public int idPatient { get; set; }
        //[ForeignKey("idPatient")]
        //public virtual Patient patient { get; set; }
    }
}