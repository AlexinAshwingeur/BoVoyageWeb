using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BoVoyageWeb.Models
{
    [Table("Voyages")]
    public class Voyage
    {
        public int Id { get; set; }

        [Required]
        public DateTime DateAller { get; set; }

        [Required]
        public DateTime DateRetour { get; set; }

        public int PlacesDisponibles { get; set; }

        public decimal PrixParPersonne { get; set; }

        public List<DossierReservation> Dossiers { get; set; }

        public int IdAgenceVoyage { get; set; }
        [ForeignKey("IdAgenceVoyage")]
        public AgenceVoyage AgenceVoyage { get; set; }

        public int IdDestination { get; set; }
        [ForeignKey("IdDestination")]
        public Destination Destination { get; set; }


    }
}