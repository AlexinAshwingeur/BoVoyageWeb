using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace BoVoyageWeb.Models
{
    [Table("AgencesVoyages")]
    public class AgenceVoyage
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nom { get; set; }

        public List<Voyage> Voyages { get; set; }

    }
}
