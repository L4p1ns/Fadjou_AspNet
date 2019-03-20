using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fadiou.Models
{
    public class RendezVous
    {
        [Key]
        public int IdRv { get; set; }

        [Display(Name = "Date Rendez vous")]
        public DateTime DateRv { get; set; }

        [MaxLength(40, ErrorMessage = "taille maximale 40"),
          Required(ErrorMessage = "*")]
        [Display(Name = "Motif du rendez vous")]
        public String MotifRv { get; set; }
        public int idPatient { get; set; }
        [ForeignKey("idPatient")]
        public virtual Patient patient { get; set; }
    }
}