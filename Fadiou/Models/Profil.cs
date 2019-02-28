using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fadiou.Models
{
    public class Profil
    {
        [Key]
        public int idProfil { get; set; }
        [MaxLength(10)]
        public string codeProfil { get; set; }
        [MaxLength(40)]
        public string libelleProfil { get; set; }

    }
}