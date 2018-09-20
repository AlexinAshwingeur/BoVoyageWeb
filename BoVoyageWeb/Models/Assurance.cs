using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BoVoyageWeb.Models
{
    public class Assurance
    {
        
       public int Id { get; set; }
       public decimal Montant { get; set; }
       public string Type { get; set; }
       public int Code { get; set; }
        
    }
}