﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BoVoyageWeb.Models
{
    public class Participant : Personne
    {
        public int NumeroUnique { get; set; }

        public float Reduction { get; set; }
    }
}