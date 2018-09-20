using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BoVoyageWeb.Models
{
    [Table("DossierReservations")]
    public class DossierReservation
    {
        public int Id { get; set; }

        [Required]
        public string NumeroCarteBancaire { get; set; }

        public decimal PrixParPersonne { get; set; }

        [NotMapped]
        public decimal PrixTotal { get; set; }

        public int IdVoyage { get; set; }
        [ForeignKey("IdVoyage")]
        public Voyage Voyage { get; set; }

        public int IdClient { get; set; }
        [ForeignKey("IdClient")]
        public Client Client { get; set; }

        [NotMapped]
        public byte EtatDossierReservation { get; set; }

        public ICollection<Assurance> Assurances { get; set; }

        public  ICollection<Participant> ListParticipants { get; set; }
    }
}