using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fadiou.Models
{
    public class Ordonnance
    {
        [Key]
        public int IdOrdonnance{ get; set; }

        [Display(Name = "Date Ordonance")]
        public DateTime DateOrdonnance { get; set; }

        [MaxLength(40, ErrorMessage = "taille maximale 40"),
          Required(ErrorMessage = "*")]
        [Display(Name = "Description Ordonance")]
        public String DescOrdonance { get; set; }

        public int idConsultation { get; set; }
        [ForeignKey("idConsultation")]
        public virtual Consultation consultation { get; set; }

    }
}