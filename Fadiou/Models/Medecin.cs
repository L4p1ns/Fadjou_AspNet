using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fadiou.Models
{
    public class Medecin
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idMed { get; set; }
        [ForeignKey("idMed")]
        public virtual Personne personne { get; set; }

        [MaxLength(80, ErrorMessage = "taille maximale 80"), 
            Required(ErrorMessage = "*")]
        [Display(Name = "Specialite")]
        public string specialteMed{ get; set; }
    }
}