using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fadiou.Models
{
    public class Patient
    {
        [Key]
        public int idPatient { get; set; }

        [Display(Name ="Nom")]
        [MaxLength(80, ErrorMessage =("Taille maximale 80")), Required(ErrorMessage ="*")]
        public string nomPatient { get; set; }

        [Display(Name = "Prénom")]
        [MaxLength(80, ErrorMessage = ("Taille maximale 80")), Required(ErrorMessage = "*")]
        public string prenomPatient { get; set; }

        [Display(Name = "Adresse")]
        [MaxLength(150, ErrorMessage = ("Taille maximale 150"))]
        public string adressePatient { get; set; }

        [Display(Name = "Date de naissance")]
        [Required(ErrorMessage = "*")]
        public DateTime dateNaissancePatient { get; set; }

        [Display(Name = "Sexe")]
        [StringLength(1, ErrorMessage = ("Taille maximale 1")), Required(ErrorMessage = "*")]
        public string sexePatient { get; set; }

        [Display(Name = "Téléphone")]
        [MinLength(9, ErrorMessage = ("Taille minimale 9")), MaxLength(20, ErrorMessage = ("Taille maximale 20")), Required(ErrorMessage = "*")]
        public string telPatient { get; set; }

        [Display(Name = "Poids")]
        public double? poidsPatient { get; set; }

        [Display(Name = "Taille")]
        public double? taillePatient { get; set; }

        [Display(Name = "Groupe sanguin")]
        [MinLength(1, ErrorMessage = ("Taille minimale 1")), MaxLength(3, ErrorMessage = ("Taille maximale 3")), Required(ErrorMessage = "*")]
        public string groupeSanguinPatient { get; set; }

        [Display(Name = "Situation matrimoniale")]
        [MaxLength(30, ErrorMessage = ("Taille maximale 30"))]
        public string situationMatrimonialePatient { get; set; }

        [Display(Name = "Profession")]
        [MaxLength(50, ErrorMessage = ("Taille maximale 50"))]
        public string ProfessionPatient { get; set; }

        [Display(Name = "C.N.I ou passport")]
        [MaxLength(11, ErrorMessage = ("Taille maximale 11"))]
        public string cniPatient { get; set; }

        [Display(Name = "Email")]
        [MaxLength(80, ErrorMessage = ("Taille maximale 80")), Required(ErrorMessage ="*")]
        [DataType(DataType.EmailAddress)]
        public string emailPatient { get; set; }
    }
}