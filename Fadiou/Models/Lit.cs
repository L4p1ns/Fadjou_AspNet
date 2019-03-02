using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Fadiou.Models
{
    public class Lit
    {
        [Key]
        public int idLit { get; set; }

        [MaxLength(2, ErrorMessage = "taille maximale 2"), 
            Required(ErrorMessage = "*")]
        [Display(Name = "Code Lit")]
        public string codeLit { get; set; }

        public int  idChambre { get; set; }
        [ForeignKey("idChambre")]
        public virtual Chambre Chambre { get; set; }
    }
}