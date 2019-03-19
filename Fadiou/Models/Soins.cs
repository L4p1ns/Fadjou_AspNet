using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fadiou.Models
{
    public class Soins
    {
        [Key]
        public int IdSoin { get; set; }

        [Display(Name = "Date Soin")]
        public DateTime DateSoin { get; set; }

        [MaxLength(40, ErrorMessage = "taille maximale 40"),
          Required(ErrorMessage = "*")]
        [Display(Name = "Description Soin")]
        public String Soin { get; set; }

        public int idConsultation { get; set; }
        [ForeignKey("idConsultation")]
        public virtual Consultation consultation { get; set; }
    }
}