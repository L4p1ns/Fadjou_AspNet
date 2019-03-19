using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fadiou.Models
{
    public class Consultation
    {
        [Key]
        public int IdConsultation { get; set; }

        [Display(Name = "Date consultation")]
        public DateTime DateConsultation { get; set; }

        [MaxLength(40, ErrorMessage = "taille maximale 40"),
          Required(ErrorMessage = "*")]
        [Display(Name = "Diagnostique consultation")]
        public String Diagnostique { get; set; }

        public int idFileAttente { get; set; }
        [ForeignKey("idFileAttente")]
        public virtual FileAttente fileAttente { get; set; }

        //public int idRendezVous { get; set; }
        //[ForeignKey("idRendezVous")]
        //public virtual RendezVous rendezVous{ get; set; }

    }
}