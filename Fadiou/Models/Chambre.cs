using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Fadiou.Models
{
    public class Chambre
    {
        [Key]
        public int idCh { get; set; }

        [MaxLength(2, ErrorMessage = "taille maximale 2"), 
            Required(ErrorMessage = "*")]
        [Display(Name = "Code")]
        public string codeCh { get; set; }

        [MaxLength(80, ErrorMessage = "taille maximale 80"), 
            Required(ErrorMessage = "*")]
        [Display(Name = "Dénomination")]
        public string libelle { get; set; }      
        
    }
}