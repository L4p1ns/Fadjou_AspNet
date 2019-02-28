using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Fadiou.Models
{
    public class bdFadiouContext:DbContext
    {
        public bdFadiouContext():base("connFadiou")
        { }

        public DbSet<Profil> profils { get; set; }
        public DbSet<Patient> patients { get; set; }
        public DbSet<Chambre> chambres { get; set; }
        public DbSet<Lit> lits { get; set; }
        public DbSet<Infirmier> infirmiers { get; set; }
        public DbSet<Medecin> medecins { get; set; }
        public DbSet<Personne> personnes { get; set; }
        public DbSet<Personnel> personnels { get; set; }
    }
}