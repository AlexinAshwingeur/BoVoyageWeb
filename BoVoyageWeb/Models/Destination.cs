using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BoVoyageWeb.Models
{
    [Table("Destinations")]
    public class Destination
    {
        public int Id { get; set; }

        public string Continent { get; set; }

        [Required]
        public string Pays { get; set; }

        public string Region { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

        public List<Voyage> Voyages { get; set; }

    }
}