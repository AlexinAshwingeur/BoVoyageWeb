using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BoVoyageWeb.Models
{
    [Table("Assurances")]
    public class Assurance
    {
        
       public int Id { get; set; }
       public decimal Montant { get; set; }
       public string Type { get; set; }
       public int Code { get; set; }
        
    }
}