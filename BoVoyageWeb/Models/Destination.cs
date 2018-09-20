using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BoVoyageWeb.Models
{
    public class Destination
    {
        public int Id { get; set; }

        public string Continent { get; set; }

        public string Pays { get; set; }

        public string Region { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

        public List<Voyage> Voyages { get; set; }

    }
}