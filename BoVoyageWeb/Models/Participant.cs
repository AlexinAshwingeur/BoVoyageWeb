using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BoVoyageWeb.Models
{
    [Table("Participants")]
    public class Participant : Personne
    {
        public int NumeroUnique { get; set; }

        public float Reduction { get; set; }
    }
}