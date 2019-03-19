using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fadiou.Models
{
    public class Facture
    {
        [Key]
        public int IdFacture { get; set; }

        [Display(Name = "Date Facture")]
        public DateTime DateFacture { get; set; }

        [MaxLength(20, ErrorMessage = "taille maximale 20"),
          Required(ErrorMessage = "*")]
        [Display(Name = "Montant Facture")]
        public Double Montant { get; set; }

        public int idConsultation { get; set; }
        [ForeignKey("idConsultation")]
        public virtual Consultation consultation { get; set; }
    }
}