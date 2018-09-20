using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BoVoyageWeb.Models
{

    public abstract class Personne
    {
        public int Id { get; set; }

        public string Civilite { get; set; }

        [Required]
        [StringLength(30)]
        public string Nom { get; set; }

        public string Prenom { get; set; }

        public string Adresse { get; set; }

        public string Telephone { get; set; }

        public DateTime DateNaissance { get; set; }

        [NotMapped]
        public int Age { get; set; }
    }
}
 